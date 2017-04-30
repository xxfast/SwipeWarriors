using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsible : MonoBehaviour {

	public bool initiater = false;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag.Contains("enemy")){
			initiater = !collision.gameObject.GetComponent<Collapsible>().initiater;
			if (initiater) {
				collision.gameObject.GetComponent<Collapsible>().enabled = false;
				collision.gameObject.transform.SetParent (this.gameObject.transform);
				Destroy (collision.gameObject.GetComponent<Rigidbody2D> ());
			}
		}
	}
}
