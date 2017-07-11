using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructableEntity : MonoBehaviour {

    public float spawnProtectionTime = 0.1f;
    public float maxHealth = 10;
    public float currentHealth;

    private float spawnProtectionTimeRemaining;

    public bool IsDestroyed { get { return (currentHealth <= 0); } }
    public float CurrentHealth { get { return currentHealth; } }

    protected void Start() {
        currentHealth = maxHealth;
        spawnProtectionTimeRemaining = spawnProtectionTime;
    }
    protected void Update() {
        if(spawnProtectionTimeRemaining > 0)
            spawnProtectionTimeRemaining -= Time.deltaTime;
    }

    public virtual void Destruct() {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damage) {
        currentHealth -= damage;
    }

    public virtual bool IsSpawnProtected() {
        return spawnProtectionTimeRemaining > 0;
    }
}