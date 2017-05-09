using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownessOnImpact : MonoBehaviour {

	public float slownessFactor = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnTriggerEnter2D(Collider2D e)
	{
		if(e.gameObject.GetComponent<PathMovement> ()){
			e.gameObject.GetComponent<PathMovement> ().speed = e.gameObject.GetComponent<PathMovement>().speed / slownessFactor;
		}

		if (e.gameObject.GetComponent<Rigidbody2D> ()) {
			e.gameObject.GetComponent<Rigidbody2D> ().drag = e.gameObject.GetComponent<Rigidbody2D> ().drag / slownessFactor;
			e.gameObject.GetComponent<Rigidbody2D> ().angularDrag = e.gameObject.GetComponent<Rigidbody2D> ().angularDrag / slownessFactor;
		}
	}

	private void OnTriggerExit2D(Collider2D e)
	{
		if(e.gameObject.GetComponent<PathMovement> ()){
			e.gameObject.GetComponent<PathMovement> ().speed = e.gameObject.GetComponent<PathMovement>().speed * slownessFactor;
		}
		if (e.gameObject.GetComponent<Rigidbody2D> ()) {
			e.gameObject.GetComponent<Rigidbody2D> ().drag = e.gameObject.GetComponent<Rigidbody2D> ().drag * slownessFactor;
			e.gameObject.GetComponent<Rigidbody2D> ().angularDrag = e.gameObject.GetComponent<Rigidbody2D> ().angularDrag * slownessFactor;
		}
	}
}
