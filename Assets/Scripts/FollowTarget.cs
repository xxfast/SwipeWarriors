using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public GameObject target;
	[Range(0f,0.1f)] public float followSpeed;
	[Range(1f,10f)] public float rotationSpeed;

	void Start () {
	}

	void Update () {
		if(target){
			this.rotate (rotationSpeed);
			var d = distanceTo(target.transform.position);
			if (d > target.transform.localScale.x/2){
				var dx = (target.transform.position.x - this.transform.position.x) / d;
				var dy = (target.transform.position.y - this.transform.position.y) / d;
				this.move(dx * followSpeed, dy * followSpeed );
			}
		}
	}

	private float distanceTo(Vector2 point){
		Vector2 a = this.transform.position;
		Vector2 b = point;
		return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
	}

	private void move(float x, float y){
		this.transform.position = new Vector2 (this.transform.position.x + x, this.transform.position.y + y);
	}

	private void rotate(float by){
		this.transform.Rotate (new Vector3 (0, 0, by));
	}
}
