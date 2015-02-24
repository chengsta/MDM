using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public float jumpSpeed;
	public float jumpTime;
	bool jumping = false;
	public float gravity;

	private float timer;
	IEnumerator Jump() {
		while (timer > 0) {
			setVertSpeed(jumpSpeed);
			timer -= Time.deltaTime;
			yield return null;
		}
		setVertSpeed (jumpSpeed/4);
	}

	IEnumerator SwapCheck() {
		while (true) {
			if (Input.GetButtonDown("Action")) {
				Camera.main.GetComponent<LockController>().swapPosition();
				break;
			}
			yield return null;
		}
	}

	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<LockController> ().players.Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		//menu stuff, maybe move later
		if (Input.GetButtonDown("Restart")) {
			Physics.gravity = new Vector3(0, -40.0f, 0);
			Application.LoadLevel(Application.loadedLevelName);
		}

		if (Input.GetButtonDown("Cancel")) {
			Application.LoadLevel("Main_menu");
		}


		//gravity = Physics.gravity.y;

		if (Input.GetButtonDown("Jump")) {
			if (IsGrounded()) {

				timer = jumpTime;
				StartCoroutine("Jump");
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
		else if (coll.GetComponent<ReverseSwitch>()) {
			Camera.main.GetComponent<LockController> ().reverse_gravity();
		}
		else if (coll.GetComponent<SwapSwitch>()) {
			StartCoroutine("SwapCheck");
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.GetComponent<SwapSwitch>()) {
			StopCoroutine("SwapCheck");
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
		rigidbody.velocity = new Vector3(x, rigidbody.velocity.y, 0);
	}
	
	void setVertSpeed(float y) {
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, y, 0);
	}

	void lock_movement() {
		Camera.main.GetComponent<LockController> ().lock_movement ();
	}

	void unlock_movement() {
		Camera.main.GetComponent<LockController> ().unlock_movement ();
	}

	public void reverse_gravity() {
		StopCoroutine("Jump");
		gravity = -gravity;
		jumpSpeed = -jumpSpeed;
		jumping = false;
		Physics.gravity = new Vector3(0, gravity, 0);
//		Quaternion newRotation;
//		if (gravity > 0)
//			newRotation = Quaternion.Euler(0,180,0);
//		else
//			newRotation = Quaternion.Euler(0,0,0);
		//transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);
	}

}
