using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	private float rotationSpeed = 50.0f;

	private Rigidbody2D rigidBody;

	void Start() {
		this.rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) {

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
				
			Vector3 dir = directionVector + new Vector3 (0, Mathf.Sin(yRotation * Mathf.Deg2Rad), 0.0f);
			Debug.Log ("ROTATION: " + this.transform.localEulerAngles);
			// - Apply front force
			Debug.Log ("Applying force to: " + dir);
			this.rigidBody.AddForce(dir * speed);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			// - Rotate left
			this.transform.Rotate (new Vector3 (0.0f, 0.0f, rotationSpeed * Time.deltaTime));
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			// - Rotate right
			this.transform.Rotate(new Vector3(0.0f, 0.0f, -rotationSpeed*Time.deltaTime));
		}
	}
}
