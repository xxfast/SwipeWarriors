using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipEngine : MonoBehaviour {

    public float speed;
    public Rigidbody2D hull;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
