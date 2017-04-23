using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	public void Arise(int score) {
		Invoke ("InternalArise", 1.0f);
		scoreText.text = score.ToString ();
	}

	private void InternalArise() {
		// - Delayed arising
		animator.SetBool ("GameOver", true);
	}

	public void Hide() {
		animator.SetBool ("GameOver", false);
	}
}
