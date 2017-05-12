using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamingBehavior : DiscoverBehavior {

	public GameObject preteamingTarget;


	public new void Start(){
		base.Start ();
		lookForTag = this.gameObject.tag;
		preteamingTarget = this.gameObject.GetComponent<FollowTarget> ().target;
	}

	public new void Update(){
		base.Update ();
		if (Interested != null)
			ShouldObserve = false;
	}

	void OnCollisionEnter2D(Collision2D theCollider)
	{
		if (theCollider.gameObject == Interested)
		{
			ConfirmTarget(preteamingTarget);
		}
	}
}
