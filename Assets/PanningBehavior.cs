using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningBehavior : MonoBehaviour {

	public GameObject player;
	public GameObject anchor;

	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = player.transform.position - anchor.transform.position;
		newPosition.z -= 100;
		this.transform.position =  newPosition;
	}
}
