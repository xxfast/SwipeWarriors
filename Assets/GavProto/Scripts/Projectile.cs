﻿using System.Collections; using System.Collections.Generic; using UnityEngine; using System.Linq;  public class Projectile : MonoBehaviour {      public float damage;     public GameObject owner;  	// Use this for initialization 	void Start () { 		 	} 	 	// Update is called once per frame 	void Update () { 		 	}      void OnCollisionEnter2D(Collision2D collision) {         if (!new List<Collider2D>(owner.GetComponentsInChildren<Collider2D>()).Contains(collision.collider)) {
            Destroy(gameObject);
        }        } } 