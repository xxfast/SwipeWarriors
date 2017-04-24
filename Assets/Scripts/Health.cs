using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    // Base Variables
    [Header("Base Variables:")]
    [SerializeField]
    private int health;
    public int MaxHealth;

    // Base Flags
    [Header("Base Flags:")]
    [SerializeField]
    private bool alive;
    public bool DebugValues;
    public bool DebugIndication;

    // Use this for initialization
    void Start () {
        health = MaxHealth;
        alive = true;
	}

    public int CurrentHealth
    {
        get
        {
            return health;
        }
    }

    public bool IsDead
    {
        get
        {
            return !alive;
        }
    }

    /// <summary>
    /// Deals Damage
    /// </summary>
    /// <param name="amount">Amount of damage to deal.</param>
    public void DealDamage(int amount)
    {
        ApplyDelta(-amount);
    }

    /// <summary>
    /// Apply Change to Health.
    /// </summary>
    /// <param name="delta">Change to make to Health.</param>
    public void ApplyDelta(int delta)
    {
        // Apply Delta
        health += delta;
        if (DebugValues) Debug.Log("Health Changed: " + delta + " Added, " + health + " Total.");
        // Check Upper Limit
        if (health >= MaxHealth)
        {
            if (DebugIndication) Debug.Log("Health Full.");
            health = MaxHealth;
        }

        // Check Lower Limit
        if (health <= 0)
        {
            if (DebugIndication) Debug.Log("Health Empty.");
            health = 0;
            alive = false;
        }
    }
}
