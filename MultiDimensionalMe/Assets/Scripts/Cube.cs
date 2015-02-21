using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	private float distToGround;
	private Vector3 width;

	// Use this for initialization
	void Start () {
		distToGround = collider.bounds.extents.y;
		width = new Vector3(collider.bounds.extents.x, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsGrounded() {
		return Physics.Raycast(transform.position + width, -Vector3.up, distToGround + 0.1f) ||
			Physics.Raycast(transform.position - width, -Vector3.up, distToGround + 0.1f);
	}

	public void SetParent(GameObject go) {
		transform.parent = go.transform;

	}
}
