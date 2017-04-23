using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 3.0f;
	[SerializeField]
	private float rotationSpeed = 230.0f;
	[SerializeField]
	private float decreasingVelocity = 0.1f;

	private Rigidbody2D rigidBody;
	private GameController gameController;

	void Start() {
		this.rigidBody = GetComponent<Rigidbody2D> ();
		this.gameController = FindObjectOfType<GameController> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0.0f) {

			float yRotation = this.transform.eulerAngles.z;
			Vector3 directionVector = Vector3.right;
			if (yRotation > 0 && yRotation <= 90) {
				// - right
			} else if(yRotation > 90 && yRotation <= 180) {
				// - left
				directionVector = Vector3.left;
			} else if(yRotation > 180 && yRotation <= 270) {
				// - left
				directionVector = Vector3.left;
			} else if(yRotation > 270 && yRotation <= 360) {
				// - right
			}
				
			// - Apply front force
			Vector3 dir = directionVector + new Vector3 (0, Mathf.Sin(yRotation * Mathf.Deg2Rad), 0.0f);
			this.rigidBody.AddForce(dir * speed);
			Debug.Log ("MOVE FORWARD");
		}

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetAxis("PS4_Right_Analog_Hor") < 0.0f) {
			Debug.Log ("ROTATE LEFT");
			// - Rotate left
			this.transform.Rotate (new Vector3 (0.0f, 0.0f, rotationSpeed * Time.deltaTime));
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetAxis("PS4_Right_Analog_Hor") > 0.0f) {
			Debug.Log ("ROTATE RIGHT");
			// - Rotate right
			this.transform.Rotate(new Vector3(0.0f, 0.0f, -rotationSpeed*Time.deltaTime));
		}

		if (this.rigidBody.velocity.magnitude > 0f) {
			this.rigidBody.velocity *= decreasingVelocity;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		// - Die by tile
		Tile tile = col.GetComponent<Tile>();
		if (tile != null && tile.GetType() == Tile.Type.BROKEN_ICE) {
			Invoke ("Fall", 0.2f);
		}

		// - Die by screen limits
		if (col.tag == "Wall") {
			Invoke ("Fall", 0.1f);
		}
	}

	private void Fall() {
		// - FALL!
		gameController.Fall();
	}
}
