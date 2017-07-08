using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

    public float maxHealth = 10;
    public float currentHealth;

    public bool IsDestroyed { get { return (currentHealth <= 0); } }
    public float CurrentHealth { get { return currentHealth; } }

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    void TakeDamage(float damage) {
        //armor logic here if applicable
        currentHealth -= damage;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Projectile p = collision.collider.GetComponent<Projectile>();
        if (p) {
            TakeDamage(p.damage);
            if (currentHealth <= 0) {
                //Hardcoded contact point 0
                if (gameObject.GetComponent<Asteroid>()) gameObject.GetComponent<Asteroid>().Split( collision.contacts[0].normal );
                Destroy(gameObject);
            }
        }
    }
}
