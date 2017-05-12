using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrusiveBehavior : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D theCollider)
	{
		if (theCollider.gameObject.CompareTag("obstacle"))
		{
			this.gameObject.transform.SetParent(theCollider.gameObject.transform);
			this.enabled = false;
			this.gameObject.GetComponent<ReproductiveBehavior>().enabled = true;
			this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
			Destroy (this.gameObject.GetComponent<DiscoverBehavior> ());
			Destroy (this.gameObject.GetComponent<FollowTarget> ());
			Destroy (this.gameObject.GetComponent<Rigidbody2D> ());
		}
	}

}
