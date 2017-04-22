using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	[SerializeField]
	private Type type = Type.ICE;

	private int x;
	private int y;

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
	}

	public void setType(Type type, Sprite sprite) {
		if (this.type != type) {
			this.type = type;
			this.spriteRenderer.sprite = sprite;
		}
	}

	public enum Type {
		ICE,
		HALF_BROKEN_ICE,
		BROKEN_ICE
	}
}
