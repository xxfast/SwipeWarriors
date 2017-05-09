using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWithHealth : MonoBehaviour {

	private Health health;
	private Vector2 initalScale;
	public float minimumScale = 0.5f;

	void Start(){
		health = this.gameObject.GetComponent<Health> ();
		initalScale = this.gameObject.transform.localScale;
	}
	void Update () {
		Resize ();
	}

	void Resize(){
		float ratio = (float)health.CurrentHealth / (float)health.maxHealth;
		Vector2 newScale = new Vector2(initalScale.x * ratio, initalScale.y * ratio);
		if(newScale.magnitude>Vector2.Scale(initalScale,new Vector2(minimumScale,minimumScale)).magnitude)
			this.gameObject.transform.localScale = newScale;
	}
}
