using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {

    public Transform attackArea;
    public Rigidbody2D rigidbody;

    public float maxScale = 5f;
    public float minSpeed = 0f;
    public float maxSpeed = 10f;

    private float minRadius; 
    // Use this for initialization
    void Start () {
        minRadius = GetComponent<CircleCollider2D>().radius;
        if (attackArea == null) {
            attackArea = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        var speedFactor = rigidbody.velocity.magnitude / (maxSpeed - minSpeed);
        var scaleFactor = 1 + speedFactor;
        attackArea.localScale = Vector3.one * scaleFactor;
    }
}
