using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamingBehavior : DiscoverBehavior {

	public GameObject preteamingTarget;


	public new void Start(){
		base.Start ();
		lookForTag = this.gameObject.tag;
		var target = this.gameObject.GetComponent<FollowTarget> ().target;
		preteamingTarget = target;
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

	public override void ConfirmTarget (GameObject target)
	{
		if(target.GetComponent<TeamingBehavior>())
			base.ConfirmTarget (target);
	}
}
