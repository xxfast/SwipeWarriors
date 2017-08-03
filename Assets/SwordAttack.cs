using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

	public float attackStrength = 100;
	public float attackTime = 3;
	public int noOfTapsforAttack = 2;

	private float time;
	private int flip = 1;


	// Use this for initialization
	void Start () {
		time = attackTime;
		gameObject.GetComponent<TrailRenderer> ().Clear ();
		gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			time = attackTime;
			gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
			gameObject.GetComponent<ParticleSystem> ().Stop ();
			gameObject.GetComponent<TrailRenderer> ().enabled = false;
		}
		if (Input.GetTouch (0).tapCount >= noOfTapsforAttack) {
			time = attackTime;
			gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			gameObject.GetComponent<Rigidbody2D> ().angularVelocity = 0;
			flip = -flip;
			gameObject.GetComponent<Rigidbody2D> ().AddTorque(attackStrength * flip);
			gameObject.GetComponent<ParticleSystem> ().Play ();
			gameObject.GetComponent<TrailRenderer> ().enabled = true;
		}

	}
}
