using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour {

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

}
