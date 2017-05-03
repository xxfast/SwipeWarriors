using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour {

	public List<GameObject> groupMembers = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int count = 0;
		foreach(GameObject obj in groupMembers){
			if(obj.GetComponent<Health>().isDead){
				groupMembers.Remove (obj);
			}
		}
		if (groupMembers.Count == 0)
			Destroy (this.gameObject);
	}
}
