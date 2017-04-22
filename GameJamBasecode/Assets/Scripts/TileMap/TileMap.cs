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

	// Use this for initialization
	void Start () {
		mapData = new Tile[sizeX, sizeY];

		for (int x = 0; x < sizeX; x++) {
			for (int y = 0; y < sizeY; y++) {
				Tile tile = Instantiate (tilePrefab, new Vector2 (x-4, y-3), Quaternion.identity) as Tile;
				mapData [x, y] = tile;
				tile.transform.parent = this.transform;
			}
		}
	}
}
