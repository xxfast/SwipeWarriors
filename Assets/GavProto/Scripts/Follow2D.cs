using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Follow2D : MonoBehaviour {      public Transform target;     public Vector3 offset;     public float turnSpeed; 	// Use this for initialization 	void Start () { 		 	} 	 	// Update is called once per frame 	void Update () {         transform.position = target.position + offset;         FollowDirection2D(target);
    }

    void FollowDirection2D(Transform target) {
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * turnSpeed);
    } } 