using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public float jumpSpeed;
	public float jumpTime;

	private bool jumping = false;

	IEnumerator Jump() {
		yield return new WaitForSeconds (jumpTime);
		jumping = false;
		setVertSpeed (jumpSpeed/4);
	}


	// Use this for initialization
	void Start () {

		Camera.main.GetComponent<LockController> ().players.Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			Application.LoadLevel(Application.loadedLevelName);
		}

		if (jumping) {
			setVertSpeed(jumpSpeed);
		}

		if (Input.GetButtonDown("Jump")) {
			if (IsGrounded()) {
				//rigidbody.AddForce(Vector3.up * jumpSpeed);
				StartCoroutine("Jump");
				jumping = true;
				setVertSpeed(jumpSpeed);
			}
		}

		setHorizSpeed (Input.GetAxis("Horizontal") * moveSpeed);
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.GetComponent<LockSwitch>()) {
			lock_movement();
		}
		else if (coll.GetComponent<UnlockSwitch>()) {
			unlock_movement();
		}
	}
	
	bool IsGrounded() {
		Cube[] cubes = GetComponentsInChildren<Cube> () as Cube[];
		foreach (Cube cube in cubes) {
			if (cube.IsGrounded())
				return true;
		}

		return false;
	}
	
	void setHorizSpeed(float x) {
		rigidbody.velocity = new Vector3(x, rigidbody.velocity.y, rigidbody.velocity.z);
	}
	
	void setVertSpeed(float y) {
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, y, rigidbody.velocity.z);
	}

	void lock_movement() {
		Camera.main.GetComponent<LockController> ().lock_movement ();
	}

	void unlock_movement() {
		Camera.main.GetComponent<LockController> ().unlock_movement ();
	}


}
