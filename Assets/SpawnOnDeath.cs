using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour {

	public float dropProbability = 1; // number between 0.0 and 1.0
	public Object drops;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<Health>().isDead)
		{
			bool drop = Random.value <= dropProbability;
			if(drop)
			{
				GameObject pickup = Instantiate(drops, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
			}
		}

	}
}
