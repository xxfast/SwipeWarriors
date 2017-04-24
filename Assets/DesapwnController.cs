using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapwnController : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private Health health;

    // Use this for initialization
    void Start () {
        health = this.gameObject.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        // Destroy Self on Death
		if(health.IsDead)
        {
            Destroy(this.gameObject);
        }
	}
}
