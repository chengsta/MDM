using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LockController : MonoBehaviour {
	public Material lockColor;
	public Material unlockColor;
	public List<GameObject> players;
	private bool locked = false;

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
	
}
