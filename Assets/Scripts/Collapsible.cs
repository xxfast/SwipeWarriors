using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsible : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag.Contains("enemy")){
			collision.gameObject.GetComponent<Collapsible>().enabled = false;
			this.gameObject.transform.SetParent(collision.gameObject.transform);
			this.gameObject.GetComponent<FollowTarget>().enabled = false;
			this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
			Destroy (this.gameObject.GetComponent<Rigidbody2D> ());
		}
	}
}
