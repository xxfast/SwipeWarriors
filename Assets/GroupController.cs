using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour {

	public List<GameObject> groupMembers = new List<GameObject>();

	void Start () {
		
	}
	
	void Update () {
		int count = 0;
		foreach(GameObject obj in groupMembers){
			if(obj==null || obj.GetComponent<Health>().isDead){
				groupMembers.Remove (obj);
			}
		}
		if (groupMembers.Count == 0)
			Destroy (this.gameObject);
	}
}
