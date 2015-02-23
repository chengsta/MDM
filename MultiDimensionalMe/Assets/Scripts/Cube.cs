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
		Debug.DrawLine (transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Color.red);
	}

	public bool IsGrounded() {
		RaycastHit hit;
		if (GetComponentInParent<PlayerMovement>().gravity < 0) {
			// print("on ground/normal gravity");
			if (Physics.Raycast(transform.position + width, -Vector3.up, out hit, distToGround + 0.1f) 
			    && (hit.transform.gameObject.tag == "Platform"))
				return true;
			if (Physics.Raycast(transform.position - width, -Vector3.up, out hit, distToGround + 0.1f) 
			    && (hit.transform.gameObject.tag == "Platform"))
				return true;
		}
		else {
			//print("on ground/reverse gravity");
			// print (Vector3.up + transform.position);
			//print (Physics.Raycast(transform.position + width, transform.TransformDirection(Vector3.up), distToGround + 0.1f) ||
			//	Physics.Raycast(transform.position - width, transform.TransformDirection(Vector3.up), distToGround + 0.1f));
			if (Physics.Raycast(transform.position + width, Vector3.up, out hit, distToGround + 0.1f) 
			    && (hit.transform.gameObject.tag == "Platform"))
				return true;
			if (Physics.Raycast(transform.position - width, Vector3.up, out hit, distToGround + 0.1f) 
			    && (hit.transform.gameObject.tag == "Platform"))
				return true;
		}
		return false;
	}

	public void SetParent(GameObject go) {
		transform.parent = go.transform;

	}
}
