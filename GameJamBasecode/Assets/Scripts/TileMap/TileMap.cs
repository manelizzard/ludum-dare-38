﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	[SerializeField]
	private int sizeX = 17;
	[SerializeField]
	private int sizeY = 11;
	[SerializeField]
	private int leftOffset = 3;

	private Tile[,] mapData;

	[SerializeField]
	private Tile tilePrefab;

	private ArrayList spawnableTiles = new ArrayList ();
	private SoundController soundController;

	[SerializeField]
	private int oneHoleEachSeconds = 10;

	// Use this for initialization
	void Start () {
		soundController = FindObjectOfType<SoundController> ();
		mapData = new Tile[sizeX, sizeY];

		for (int x = 0; x < sizeX; x++) {
			for (int y = 0; y < sizeY; y++) {
				Tile tile = Instantiate (tilePrefab, new Vector2 (x-8-leftOffset, y-5), Quaternion.identity) as Tile;
				tile.x = x;
				tile.y = y;
				mapData [x, y] = tile;
				spawnableTiles.Add (tile);
				tile.transform.parent = this.transform;
			}
		}
	}

	public void BreakTile(Tile tile) {
		soundController.PlayBreak ();
		spawnableTiles.Remove (tile);
		tile.setType(Tile.Type.BROKEN_ICE);
	}

	public Tile GetSpawnableTile() {
		int randomIndex = (int) Random.Range (0.0f, spawnableTiles.Count);
		return (Tile) spawnableTiles [randomIndex];
	}

	public void RecoverTile(Tile tile) {
		tile.setType (Tile.Type.ICE);
	}

	private void MakeHole() {
		Tile tile = GetSpawnableTile ();
		BreakTile (tile);
	}

	public void StopMakingHoles() {
		CancelInvoke ("MakeHole");
	}

	public void StartMakingHoles() {
		InvokeRepeating ("MakeHole", oneHoleEachSeconds, oneHoleEachSeconds);
	}

	public void Reset() {
		for (int x = 0; x < sizeX; x++) {
			for (int y = 0; y < sizeY; y++) {
				RecoverTile (mapData [x, y]);
			}
		}
	}
}
