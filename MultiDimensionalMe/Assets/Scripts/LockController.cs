using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LockController : MonoBehaviour {
	public Material lockColor;
	public Material unlockColor;
	public List<GameObject> players;
	private bool locked = false;
	private float levelLength;

	public void lock_movement() {
		if (locked)
			return;

		players [1].GetComponentInChildren<Cube> ().SetParent(players[0]);
		players [1].SetActive (false);

		setColor (lockColor);
		locked = true;
	}

	public void unlock_movement() {
		if (!locked)
			return;

		setColor (unlockColor);

		players [1].SetActive (true);
		players [0].GetComponentInChildren<Cube> ().SetParent (players [1]);
		locked = false;
	}

	void Awake() {
		players = new List<GameObject> ();
		levelLength = transform.FindChild("RightEnd").position.x;

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setColor(Material mat) {
		Cube[] cubes = players [0].GetComponentsInChildren<Cube> () as Cube[];
		foreach(Cube cube in cubes) {
			cube.renderer.material = mat;
		}
	}

	public void reverse_gravity () {
		players [0].GetComponent<PlayerMovement>().reverse_gravity();
		players [1].GetComponent<PlayerMovement>().reverse_gravity();
	}

		void swapPositionHelp(Cube cube) {
		Vector3 pos = cube.transform.position;
		if (cube.transform.position.x < 0) {
			pos.x += levelLength;
			cube.transform.position = pos;
		}
		else {
			pos.x -= levelLength;
			cube.transform.position = pos;
		}
	}

	public void swapPosition() {
		print ("swaq");

		Cube cube1;
		Cube cube2;

		if (locked) {
			Cube[] cubes = players [0].GetComponentsInChildren<Cube> () as Cube[];
			cube1 = cubes[0];
			cube2 = cubes[1];
		}
		else {
			cube1 = players [0].GetComponentInChildren<Cube> ();
			cube2 = players [1].GetComponentInChildren<Cube> ();
		}

		swapPositionHelp(cube1);
		swapPositionHelp(cube2);


	}
}
