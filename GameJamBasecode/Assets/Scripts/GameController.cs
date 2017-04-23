using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Item itemPrefab;

	[SerializeField]
	private int remainigPlayerLifetime = 60;

	private TileMap tileMap;
	private int score = 0;

	public Text scoreText;
	public Text lifetimeText;
	public Text maxScoreText;

	private Tile currentTileWithItem;
	private SoundController soundController;
	private GameOver gameOver;
	public PlayerController playerPrefab;
	private PlayerController spawnedPlayer;
	private Item currentSpawnedItem;

	void Start() {
		gameOver = FindObjectOfType<GameOver> ();
		soundController = FindObjectOfType<SoundController> ();
		tileMap = FindObjectOfType<TileMap> ();
		StartGame ();
	}

	public void StartGame() {
		SpawnPlayer ();
		Invoke ("SpawnItem", 5f); 
		InvokeRepeating ("TickCountdown", 1f, 1f);
		maxScoreText.text = PlayerPrefs.GetInt ("maxScore").ToString();
		scoreText.text = "0";
		tileMap.StartMakingHoles();
		tileMap.Reset ();
	}

	public void Fall() {
		LoseGame();
		soundController.PlayFall ();
	}

	public void Die() {
		LoseGame();
	}

	void LoseGame() {
		if (currentSpawnedItem != null) {
			Destroy (currentSpawnedItem.gameObject);
		}

		CancelInvoke ("SpawnItem");
		CancelInvoke ("TickCountdown");
		gameOver.Arise (score);
		tileMap.StopMakingHoles();
		Destroy (this.spawnedPlayer.gameObject);
	}

	void SpawnItem() {
		currentTileWithItem = tileMap.GetSpawnableTile ();
		currentTileWithItem.setType (Tile.Type.UNBREAKABLE);
		currentSpawnedItem = Instantiate (itemPrefab, currentTileWithItem.transform.position, Quaternion.identity);
		currentSpawnedItem.transform.parent = this.transform;
		soundController.PlayItemSpawned ();
	}

	public void ItemCollected(Item item) {
		soundController.PlayGatherItem ();
		score += (int) (Random.Range(0.7f, 1.0f) * item.GetValue ());
		Invoke ("SpawnItem", 0.2f);

		if (currentTileWithItem != null) {
			tileMap.RecoverTile (currentTileWithItem);
			currentTileWithItem = null;
		}

		scoreText.text = score.ToString();
		if(score > PlayerPrefs.GetInt ("maxScore")) {
			PlayerPrefs.SetInt("maxScore", score);
		}
	}

	private void TickCountdown() {
		remainigPlayerLifetime--;

		if (remainigPlayerLifetime <= 0) {
			Die ();
			CancelInvoke ("TickCountdown");
		}
			
		lifetimeText.text = remainigPlayerLifetime.ToString() + "s";
	}

	public void IncreaseLifetime(int amount) {
		remainigPlayerLifetime += amount;
		lifetimeText.text = remainigPlayerLifetime.ToString() + "s";
	}

	public void Restart() {
		gameOver.Hide ();
		StartGame ();
	}

	private void SpawnPlayer() {
		spawnedPlayer = (PlayerController) Instantiate(this.playerPrefab, Vector3.zero, Quaternion.identity) as PlayerController;
	}

	public void QuitGame() {
		SceneManager.LoadScene ("Main Menu");
	}
}
