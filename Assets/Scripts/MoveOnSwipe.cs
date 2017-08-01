using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnSwipe : MonoBehaviour {
	
	public float speed = 100;
	private Vector2 originalScale;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		originalScale = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Moved){
			Vector2 touchDirection = Input.GetTouch (0).deltaPosition.normalized;
			Vector2 scale = originalScale;
			if (touchDirection.x < 0)
				scale.x *= -1;
			this.transform.localScale = scale;
			touchDirection.Scale (new Vector2 (speed, speed));
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (touchDirection);
		}
	}
}
