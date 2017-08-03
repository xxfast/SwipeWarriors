using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FreezeRotation : MonoBehaviour {

	public bool freeze = true;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().freezeRotation = freeze;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().freezeRotation = freeze;
	}
}
