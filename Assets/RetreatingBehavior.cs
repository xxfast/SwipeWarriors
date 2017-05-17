using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowTarget))]
[RequireComponent(typeof(RiskAversionBehavior))]
public class RetreatingBehavior : MonoBehaviour {

	public float noticeDistance;
	public float retreatDistance;

	private GameObject target;

	void Start () {
		target = gameObject.GetComponent<FollowTarget> ().target;
	}
	
	void Update () {
		float targetDistance = Vector2.Distance (gameObject.transform.position, target.transform.position);
		if(targetDistance<=noticeDistance){
			if(!gameObject.GetComponent<RiskAversionBehavior>().IsAbleToDefeatEnemy(target)){
				FleeFromTarget ();
			}
		}
	}

	public void FleeFromTarget(){
		gameObject.GetComponent<FollowTarget> ().target = null;
	}
}
