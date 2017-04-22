using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	[SerializeField]
	private int sizeX = 9;
	[SerializeField]
	private int sizeY = 6;
	[SerializeField]
	private int tileSize = 1;

	private Tile[,] mapData;

	[SerializeField]
	private Sprite[] sprites;
	[SerializeField]
	private Tile tilePrefab;

	private ArrayList spawnableTiles = new ArrayList ();

	[SerializeField]
	private int oneHoleEachSeconds = 10;

	// Use this for initialization
	void Start () {
		mapData = new Tile[sizeX, sizeY];

		for (int x = 0; x < sizeX; x++) {
			for (int y = 0; y < sizeY; y++) {
				Tile tile = Instantiate (tilePrefab, new Vector2 (x-4, y-3), Quaternion.identity) as Tile;
				tile.x = x;
				tile.y = y;
				mapData [x, y] = tile;
				spawnableTiles.Add (tile);
				tile.transform.parent = this.transform;
			}
		}

		InvokeRepeating ("MakeHole", oneHoleEachSeconds, oneHoleEachSeconds);
	}

	public void BreakTile(Tile tile) {
		spawnableTiles.Remove (tile);
		tile.setType(Tile.Type.BROKEN_ICE, sprites[2]);
	}

	public Tile GetSpawnableTile() {
		int randomIndex = (int) Random.Range (0.0f, spawnableTiles.Count);
		return (Tile) spawnableTiles [randomIndex];
	}

	public void RecoverTile(Tile tile) {
		tile.setType (Tile.Type.ICE, sprites [0]);
	}

	private void MakeHole() {
		Tile tile = GetSpawnableTile ();
		BreakTile (tile);
	}
}
