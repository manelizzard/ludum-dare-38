using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	[SerializeField]
	private AudioClip[] clipsFall;
	[SerializeField]
	private AudioClip[] clipsBreak;
	[SerializeField]
	private AudioClip[] clipsHalfBreak;
	[SerializeField]
	private AudioClip[] gatherItem;
	[SerializeField]
	private AudioClip[] clipsItemSpawn;
	[SerializeField]
	private AudioClip[] clipsDie;
	[SerializeField]
	private AudioClip[] clipsUI;
	[SerializeField]
	private AudioClip[] clipsGameOver;

	private static SoundController instance = null;

	void Start() {
		if (instance == null) {
			DontDestroyOnLoad (this.gameObject);
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	public void PlayGatherItem() {
		PlayRandomInArray (gatherItem);
	}

	public void PlayFall() {
		PlayRandomInArray (clipsFall);
	}

	public void PlayHalfBreak() {
		PlayRandomInArray (clipsHalfBreak);
	}

	public void PlayBreak() {
		PlayRandomInArray (clipsBreak);
	}

	public void PlayItemSpawned() {
		PlayRandomInArray (clipsItemSpawn);
	}

	public void PlayDie() {
		PlayRandomInArray (clipsDie);
	}

	public void PlayUI() {
		PlayRandomInArray (clipsUI);
	}

	public void PlayGameOver() {
		PlayRandomInArray (clipsGameOver);
	}
		
	private void PlayRandomInArray(AudioClip[] clips) {
		AudioClip clip = clips [(int) Random.Range (0f, clips.Length - 1f)];
		GetComponent<AudioSource> ().PlayOneShot (clip);
	}
}
