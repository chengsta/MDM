using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public string nextLevel;
	public 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		Physics.gravity = new Vector3(0, -40.0f, 0);
		Application.LoadLevel (nextLevel);
	}
}
