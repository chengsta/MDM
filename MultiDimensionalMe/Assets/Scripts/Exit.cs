using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		Application.LoadLevel (nextLevel);
	}
}
