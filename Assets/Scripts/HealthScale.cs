using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScale : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces")]
    [SerializeField]
    private Vector2 initalScale;
    [SerializeField]
    private Health health;

    //Base Variables
    // Variables
    [Header("Base Variables:")]
    [SerializeField]
    private float healthRatio;
    private int maxHealth;
    private int currentHealth;

    // Use this for initialization
    void Start () {
        initalScale = this.gameObject.transform.localScale;
        health = this.gameObject.GetComponent<Health>();
        maxHealth = health.MaxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (health.CurrentHealth != currentHealth)
        {
            currentHealth = health.CurrentHealth;
            healthRatio = 1.0f * ((float)currentHealth / (float)maxHealth);
            this.gameObject.transform.localScale = new Vector2(initalScale.x * healthRatio, initalScale.y * healthRatio);
        }
    }
}
