using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISound : MonoBehaviour {

	private SoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = FindObjectOfType<SoundController> ();
		GetComponent<Button> ().onClick.AddListener (Click);
	}

	private void Click() {
		Debug.Log ("PLAYING UI");
		soundController.PlayUI ();
	}
}
