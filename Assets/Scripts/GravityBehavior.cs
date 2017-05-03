using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour {

	public GameObject _gravitateToward;
	public GameObject jetpack;

	public float gravity = 10;

	private Vector2 direction;

	public bool shouldGravitate = true;

	void Start () {
	}
	
	void Update () {
		if (_gravitateToward) {
			Vector3 vectorToTarget = _gravitateToward.transform.position - transform.position;

			if (shouldGravitate && !this.gameObject.GetComponent<PathMovement> ().IsMoving) {
				if(jetpack) this.jetpack.GetComponent<ParticleSystem> ().Stop ();
				this.GetComponent<Rigidbody2D> ().AddForce (vectorToTarget);
			} else {
				this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				if(jetpack) this.jetpack.GetComponent<ParticleSystem> ().Play ();
			}
			
			transform.rotation = Quaternion.FromToRotation (transform.position,_gravitateToward.transform.position);
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

}
