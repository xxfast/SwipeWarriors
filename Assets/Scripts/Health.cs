﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	// Use this for initialization
	public int maxHealth = 10;
	private int currentHealth;

	private Vector2 initalScale;
   

	public bool isDead { get { return currentHealth <= 0; } }

	void Start () {
		currentHealth = maxHealth;
		initalScale = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		ResizeWithHealth ();
        if (currentHealth <= 0)
            Death();
    }

	void ResizeWithHealth(){
		float ratio = (float)currentHealth / (float)maxHealth;
		var newScale = new Vector2(initalScale.x * ratio, initalScale.y * ratio);
		this.gameObject.transform.localScale = newScale;
	}

	public void DealDamage(int amount){
		currentHealth -= amount;
	}

    void Death()
    {
        Destroy(this.gameObject);
    }
}
