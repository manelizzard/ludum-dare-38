using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadController : MonoBehaviour {

	public String nextSceneName;
	private AsyncOperation async;

	// Use this for initialization
	void Start () {
		StartCoroutine(CargaCabessa());
	}

	private IEnumerator CargaCabessa() {
		async = Application.LoadLevelAsync(nextSceneName);
		async.allowSceneActivation = false;
		yield return async;
	}

	public void Fire() {
		async.allowSceneActivation = true;
	}
}
