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
		spriteRenderer.enabled = false;
	}

	public void setType(Type type) {
		if (this.type != type) {
			this.type = type;

			// - Delay breaking ice 1 second
			if (this.type == Type.BROKEN_ICE) {
				GetComponent<Animator> ().SetBool ("Broken", true);
				GetComponent<BoxCollider2D> ().enabled = false;
				Invoke ("EnableCollider", .2f);
			} else {
				GetComponent<Animator> ().SetBool ("Broken", false);
			}

			if (this.type == Type.ICE || this.type == Type.UNBREAKABLE) {
				spriteRenderer.enabled = false;
			} else {
				spriteRenderer.enabled = true;
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
