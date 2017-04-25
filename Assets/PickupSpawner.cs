using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    // Object Refernces
    [Header("Object Refernces:")]
    public List<GameObject> Pickups;

    // Settings
    [Header("Spawner Settings:")]
    public float DropProbability;
    

	// Use this for initialization
	void Start () {
		
	}

    public void SpawnPickup(GameObject entity)
    {
        bool drop = Random.value <= DropProbability;

        if(drop)
        {
            GameObject pickup = Instantiate(Pickups[Random.Range(0, Pickups.Count - 1)], new Vector3(entity.transform.position.x, entity.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        }
    }
}
