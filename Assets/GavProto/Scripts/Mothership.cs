using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : DestructableEntity {

    public GameObject player;

	// Use this for initialization
	new void Start () {
        base.Start();
        var colliders = GetComponents<Collider2D>();
        var playerColliders = player.GetComponents<Collider2D>();
        var playerChildColliders = player.GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders) {
            foreach (var playerCol in playerColliders) {
                Physics2D.IgnoreCollision(playerCol, col);
            }
            foreach (var playerChildCol in playerChildColliders) {
                Physics2D.IgnoreCollision(playerChildCol, col);
            }
        }
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (!IsSpawnProtected()) {
            //TODO Gavin: FIX HARDCODING
            if (collision.gameObject.GetComponent<Asteroid>()) {
                float energy = collision.relativeVelocity.sqrMagnitude * collision.otherRigidbody.mass / 2;
                TakeDamage(energy);
            }
            else if (collision.gameObject.GetComponent<Projectile>()) {
                TakeDamage(collision.gameObject.GetComponent<Projectile>().damage);
            }
            Debug.Log(currentHealth);
            if (currentHealth <= 0) {
                Destruct();
            }
        }
    }
}
