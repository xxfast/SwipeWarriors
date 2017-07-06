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
            Destroy(this.gameObject);
        }
    }

    void TakeDamage(float damage) {
        //armor logic here if applicable
        currentHealth -= damage;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile p = collider.GetComponent<Projectile>();
        if (p) {
            TakeDamage(p.damage);
        }
    }
}
