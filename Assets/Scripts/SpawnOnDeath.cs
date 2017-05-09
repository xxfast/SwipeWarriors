using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour {

	public float dropProbability = 1; // number between 0.0 and 1.0
	public List<GameObject> drops;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Checks if Object is still alive
		if(this.gameObject.GetComponent<Health>().isDead)
		{
            // Spawn Objects if applicable
			bool drop = Random.value <= dropProbability;
			if(drop)
			{
                int itemToDrop = Random.Range(0, drops.Count - 1);
				GameObject pickup = Instantiate(drops[itemToDrop], new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
			}
        }
	}
}
