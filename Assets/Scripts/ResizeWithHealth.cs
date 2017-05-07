using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWithHealth : MonoBehaviour {

	private Health health;
	private Vector2 initalScale;

	void Start(){
		health = this.gameObject.GetComponent<Health> ();
		initalScale = this.gameObject.transform.localScale;
	}
	void Update () {
		Resize ();
	}

	void Resize(){
		float ratio = (float)health.CurrentHealth / (float)health.maxHealth;
		var newScale = new Vector2(initalScale.x * ratio, initalScale.y * ratio);
		this.gameObject.transform.localScale = newScale;
	}
}
