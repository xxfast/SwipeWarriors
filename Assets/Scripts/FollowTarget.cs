using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public GameObject target;
	[Range(0f,100f)] public float followSpeed;
	[Range(1f,10f)] public float rotationSpeed;

	void Start () {
		ApplyForceTowardTarget ();
	}

	void Update () {
		if(target && target.transform.hasChanged){
			ResetForces ();
			ApplyForceTowardTarget ();
		}
	}

	void ApplyForceTowardTarget(){
		if(target){
			var d = Vector2.Distance (this.transform.position,target.transform.position);
			if (d > target.transform.localScale.x/2){
				var dx = (target.transform.position.x - this.transform.position.x) / d;
				var dy = (target.transform.position.y - this.transform.position.y) / d;
				this.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(dx * followSpeed, dy * followSpeed));
			}
			this.gameObject.GetComponent<Rigidbody2D> ().AddTorque (rotationSpeed);
		}
	}

	void ResetForces(){
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		this.gameObject.GetComponent<Rigidbody2D> ().angularVelocity = 0;
	}

}
