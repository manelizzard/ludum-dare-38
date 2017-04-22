using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	[SerializeField]
	private Type type = Type.ICE;

	public int x;
	public int y;

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
	}

	public void setType(Type type) {
		setType (type, null);
	}

	public void setType(Type type, Sprite sprite) {
		if (this.type != type) {
			this.type = type;

			if (sprite != null) {
				this.spriteRenderer.sprite = sprite;
			}

			// - Delay breaking ice 1 second
			if (this.type == Type.BROKEN_ICE) {
				GetComponent<BoxCollider2D> ().enabled = false;
				Invoke ("EnableCollider", .2f);
			}
		}
	}

	private void EnableCollider() {
		GetComponent<BoxCollider2D> ().enabled = true;
	}

	public Type GetType() {
		return type;
	}

	public enum Type {
		ICE,
		HALF_BROKEN_ICE,
		BROKEN_ICE,
		UNBREAKABLE
	}
}
