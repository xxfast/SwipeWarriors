﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Component helps the Intrusive to discover floating objects 
/// and the also let its spawned children to discover the player
/// </summary>
public class DiscoverBehavior : MonoBehaviour {

	public string lookForTag = "";
	public float viewDistance = 10;
	public int viewDirectionCount = 16;
	public int observeFreaquency = 5;

	private GameObject interested;

	private float time;

	void Start () {
		Observe ();
		time = observeFreaquency;
	}
	
	void Update () {
		time -= Time.deltaTime;
		if(time<=0){
			Observe ();
			time = observeFreaquency;
		}
	}

	void Observe(){
		interested = null;
		foreach(Vector2 currentDirection in GetCircleDirections(viewDirectionCount)){
			RaycastHit2D[] hits = Physics2D.RaycastAll(this.gameObject.transform.position,currentDirection,viewDistance);
			if (hits.Length > 1) {
				foreach(RaycastHit2D hit in hits){
					if (hit.collider.gameObject != this.gameObject) {
						if(hit.collider.gameObject.tag==lookForTag)
							interested = hit.collider.gameObject;
					}
				}
			}
		}
		ConfirmTarget ();
	}

	void ConfirmTarget(){
		this.gameObject.GetComponent<FollowTarget> ().target = interested;
	}

	Vector2[] GetCircleDirections(int numDirections)
	{
		var pts = new Vector2[numDirections];
		var inc = Mathf.PI * (3 - Mathf.Sqrt(5));
		var off = 2f / numDirections;
		for(int i=0;i<numDirections;i++)
		{
			var y = i * off - 1 + (off / 2);
			var r = Mathf.Sqrt(1 - y * y);
			var phi = i * inc;
			var x = (float)(Mathf.Cos(phi) * r);
			//var z = (float)(Mathf.Sin(phi) * r);
			pts[i] = new Vector2(x, y);
		}
		return pts;
	}
}
