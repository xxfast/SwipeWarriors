using System.Collections; using System.Collections.Generic; using UnityEngine;  public class ObjectGravity : MonoBehaviour {      public double G = 6.67408e-11;     public float gravitationalStrength;     public Rigidbody2D rb;      // Use this for initialization
    void Start () { 	} 	 	// Update is called once per frame 	void Update () { 		 	}      void FixedUpdate() {
        Gravity();
    }      void Gravity() {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        foreach (var gravObj in FindObjectsOfType<ObjectGravity>()) {
            if (gravObj != this) {
                Rigidbody2D rb2 = gravObj.GetComponent<Rigidbody2D>();
                Vector3 direction = gravObj.transform.position - transform.position;
                float strength = (float) (gravitationalStrength * G * rb.mass * rb2.mass / direction.sqrMagnitude);
                Vector3 F = direction.normalized * strength;
                rb.AddForce(F * Time.fixedDeltaTime);
            }
        }
    } } 