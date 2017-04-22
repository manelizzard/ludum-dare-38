using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	[SerializeField]
	private int itemValue = 100;
	[SerializeField]
	private int timeValue = 3;

	private GameController gameController;

	void Start() {
		gameController = FindObjectOfType<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// - Item collected
		gameController.ItemCollected(this);
		gameController.IncreaseLifetime (timeValue);
		Destroy (this.gameObject);
	}

	public int GetValue() {
		return this.itemValue;
	}
}
