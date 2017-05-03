using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    public GameObject target;

    // Settings
    [Header("Settings")]
    [Range(0f, 100f)] public float FollowSpeed;
    [Range(1f, 10f)] public float RotationSpeed;

    // Use this for initialization
    void Start()
    {
        if (target == null)
            target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
		if(target && target.transform.hasChanged)
        {
            ResetForces();
            ApplyForceTowardTarget();
        }
	}

    /// <summary>
    /// Applys Force Towards Target.
    /// </summary>
    void ApplyForceTowardTarget()
    {
        if (target)
        {
            var d = Vector2.Distance(this.transform.position, target.transform.position);
            if (d > target.transform.localScale.x / 2)
            {
                var dx = (target.transform.position.x - this.transform.position.x) / d;
                var dy = (target.transform.position.y - this.transform.position.y) / d;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dx * FollowSpeed, dy * FollowSpeed));
            }
            this.gameObject.GetComponent<Rigidbody2D>().AddTorque(RotationSpeed);
        }
    }

    /// <summary>
    /// Resets Forces.
    /// </summary>
    void ResetForces()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
