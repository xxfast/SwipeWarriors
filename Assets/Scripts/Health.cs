using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth = 10;
    private int currentHealth;

	public bool isDead { get { return (currentHealth <= 0); } }

	public int CurrentHealth { get { return currentHealth; } }

	void Start () {
		currentHealth = maxHealth;
	}
	
	void Update () {
		if (currentHealth <= 0) {
			Destroy (this.gameObject);
		}
    }

	public void DealDamage(int amount){
		currentHealth -= amount;
	}
}
