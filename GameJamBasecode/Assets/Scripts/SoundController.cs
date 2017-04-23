using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	[SerializeField]
	private AudioClip[] clipsFall;
	[SerializeField]
	private AudioClip[] clipsBreak;
	[SerializeField]
	private AudioClip[] gatherItem;

	void Start() {
		DontDestroyOnLoad (this.gameObject);
	}

	public void PlayGatherItem() {
		PlayRandomInArray (gatherItem);
	}

	public void PlayFall() {
		PlayRandomInArray (clipsFall);
	}

	public void PlayBreak() {
		PlayRandomInArray (clipsBreak);
	}
		
	private void PlayRandomInArray(AudioClip[] clips) {
		AudioClip clip = clips [(int) Random.Range (0f, clips.Length - 1f)];
		AudioSource.PlayClipAtPoint (clip, this.transform.position);
	}
}
