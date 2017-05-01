using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour {

	public GameObject _gravitateToward;
	public float gravity = 10;

	private Vector2 direction;

	void Start () {
		//this.GetComponent<Rigidbody2D> ().AddForce (Vector2.MoveTowards (this.transform.position,_gravitateToward.transform.position,gravity));
	}
	
	void Update () {
		if (_gravitateToward) {
			Vector3 vectorToTarget = _gravitateToward.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * gravity);
			this.GetComponent<Rigidbody2D> ().AddForce (vectorToTarget);
		}
	}

}
