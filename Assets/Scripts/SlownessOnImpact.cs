using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownessOnImpact : MonoBehaviour {

	public float slownessFactor = 10;
	public float speed;
	public GameObject obj;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (obj)
			speed = obj.GetComponent<PathMovement> ().speed;
	}

	private void OnTriggerEnter2D(Collider2D e)
	{
		obj = e.gameObject;
		e.gameObject.GetComponent<PathMovement> ().speed = gameObject.GetComponent<PathMovement>().speed / slownessFactor;
	}

	private void OnTriggerExit2D(Collider2D e)
	{
		obj = e.gameObject;
		e.gameObject.GetComponent<PathMovement> ().speed = gameObject.GetComponent<PathMovement>().speed * slownessFactor;
	}
}
