using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBehavior : MonoBehaviour {

	public float lifeTime = 10.0f;

	private float time;

	void Start () {
		time = lifeTime;
	}
	
	void Update () {
		time -= Time.deltaTime;
		if(time<=0){
			Destroy (this.gameObject);
		}
	}
}
