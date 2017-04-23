using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	private Animator animator;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = FindObjectOfType<SoundController> ();
		animator = GetComponent<Animator> ();
	}

	public void Arise(int score) {
		Invoke ("InternalArise", 1.0f);
		scoreText.text = score.ToString ();
	}

	private void InternalArise() {
		// - Delayed arising
		animator.SetBool ("GameOver", true);
		soundController.PlayGameOver ();
	}

	public void Hide() {
		animator.SetBool ("GameOver", false);
	}
}
