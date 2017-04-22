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

	private Tile currentTileWithItem;

	void Start() {
		tileMap = FindObjectOfType<TileMap> ();
		Invoke ("SpawnItem", 5f); 
		InvokeRepeating ("TickCountdown", 1f, 1f);
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
		CancelInvoke ("SpawnItem");
		Invoke ("SpawnItem", 2f);

		if (currentTileWithItem != null) {
			tileMap.RecoverTile (currentTileWithItem);
			currentTileWithItem = null;
		}

		scoreText.text = score.ToString();
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
