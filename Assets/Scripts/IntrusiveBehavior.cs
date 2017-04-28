using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrusiveBehavior : MonoBehaviour {

	public GameObject toIntrude;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D theCollider)
	{
		if (theCollider.gameObject.CompareTag("obstacle"))
		{
			this.gameObject.transform.SetParent(theCollider.gameObject.transform);
			this.gameObject.GetComponent<FollowTarget>().enabled = false;
			Destroy (this.gameObject.GetComponent<Rigidbody2D> ());
		}
	}

}
