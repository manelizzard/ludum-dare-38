using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {
		SceneManager.LoadScene ("Main Menu");
	}
}
