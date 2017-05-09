using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningBehavior : MonoBehaviour {

	public GameObject player;
	public GameObject anchor;

	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = Vector2.Lerp( player.transform.position, anchor.transform.position,0.5f);
		newPosition.z -= 100;
		this.transform.position =  newPosition;
	}
}
