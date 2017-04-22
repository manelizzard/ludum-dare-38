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

	void Start() {
		tileMap = FindObjectOfType<TileMap> ();
		Invoke ("SpawnItem", 5f); 
		InvokeRepeating ("TickCountdown", 1f, 1f);

		maxScoreText.text = PlayerPrefs.GetInt ("maxScore").ToString();
		scoreText.text = "0";
	}

	public void Fall() {
		LoseGame();
	}

	public void Die() {
		LoseGame();
	}

	void LoseGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	void SpawnItem() {
		currentTileWithItem = tileMap.GetSpawnableTile ();
		currentTileWithItem.setType (Tile.Type.UNBREAKABLE);
		Item item = Instantiate (itemPrefab, currentTileWithItem.transform.position, Quaternion.identity);
		item.transform.parent = this.transform;
	}

	public void ItemCollected(Item item) {
		score += (int) (Random.Range(0.7f, 1.0f) * item.GetValue ());
		SpawnItem ();

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
}
