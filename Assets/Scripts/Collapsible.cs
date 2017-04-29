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
			collision.gameObject.transform.SetParent(this.gameObject.transform);
		}
	}
}
