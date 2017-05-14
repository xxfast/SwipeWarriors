using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsible : MonoBehaviour {

	public bool initiater = false;
	public GameObject groupController;


	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag.Contains("enemy")){
			//nominate the initiater
			if(collision.gameObject.GetComponent<Collapsible>() == null) return;
			initiater = !collision.gameObject.GetComponent<Collapsible>().initiater;
			if (initiater) {
				//initiate the group controller
				if(this.groupController==null && collision.gameObject.GetComponent<Collapsible>().groupController==null)
					groupController = Instantiate (Resources.Load<GameObject>("GroupController"), collision.transform.position, new Quaternion (0, 0, 0, 0)) as GameObject;

				groupController.GetComponent<GroupController> ().groupMembers.Add (this.gameObject);
				groupController.GetComponent<GroupController> ().groupMembers.Add (collision.gameObject);
				groupController.GetComponent<Collapsible> ().groupController = groupController;

				//Make them it's children 
				collision.gameObject.transform.SetParent (groupController.transform);
				this.gameObject.transform.SetParent (groupController.transform);

				//Change follow targets
				groupController.GetComponent<FollowTarget> ().target = this.gameObject.GetComponent<TeamingBehavior> ().preteamingTarget;
				groupController.GetComponent<FollowTarget> ().rotationSpeed = this.gameObject.GetComponent<FollowTarget> ().rotationSpeed;
				groupController.GetComponent<FollowTarget> ().followSpeed = this.gameObject.GetComponent<FollowTarget> ().followSpeed;


				this.gameObject.GetComponent<FollowTarget> ().target = groupController;
				this.gameObject.GetComponent<FollowTarget> ().rotationSpeed = 0;
				collision.gameObject.GetComponent<FollowTarget> ().rotationSpeed = 0;
				collision.gameObject.GetComponent<FollowTarget> ().target = groupController;


				//disable collapsoble behavior on children
				Destroy(collision.gameObject.GetComponent<Collapsible>());//.enabled = false;
				Destroy(this);//.enabled = false;

			}
		}
	}
}
