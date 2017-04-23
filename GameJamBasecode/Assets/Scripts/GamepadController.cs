using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamepadController : MonoBehaviour {

	public Button xButton;
	public Button oButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// - X button
		if (Input.GetButtonDown ("PS4_Button_X")) {
			xButton.onClick.Invoke ();
		}
			
		// - O button
		if (Input.GetButtonDown ("PS4_Button_O")) {
			oButton.onClick.Invoke ();
		}
	}
}
