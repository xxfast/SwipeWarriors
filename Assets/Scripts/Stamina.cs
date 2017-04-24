using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stamina Object.
/// </summary>
public class Stamina : MonoBehaviour {

    // Base Variables
    [Header("Base Variables:")]
    [SerializeField]
    private int stamina;
    public int MaxStamina;

    // Flags
    [Header("Base Variables:")]
    [SerializeField]
    private bool crashed;
    [SerializeField]
    private bool moving;
    public bool DebugValues;
    public bool DebugIndication;

    // Common Delta
    [Header("Common Delta:")]
    public int MoveDrain;
    public int AttackDrain;

    public int StandardRestore;
    public int CrashedRestore;

    // Constants
    [Header("Constants:")]
    public int MinimumToMove;


    /// <summary>
    /// Readonly Property to access state of crash.
    /// </summary>
    public bool HasCrashed
    {
        get
        {
            return crashed;
        }
    }

    /// <summary>
    /// Readonly Property to access current stamina.
    /// </summary>
    public int CurrentStamina
    {
        get
        {
            return stamina;
        }
    }

    /// <summary>
    /// Readonly Property to access state of moveing flag.
    /// </summary>
    public bool IsMoving
    {
        get
        {
            return moving;
        }
    }

    // Use this for initialization
    void Start () {
        crashed = false;
	}

    /// <summary>
    /// Sets Movement Flag to "Moving"
    /// </summary>
    public void StartMoving()
    {
        moving = true;
    }

    /// <summary>
    /// Sets Movement Flag to "Not Moving"
    /// </summary>
    public void StopMoving()
    {
        moving = false;
    }

    /// <summary>
    /// Step Movement.
    /// </summary>
    /// <returns>If stamina allows movement.</returns>
    public bool Move()
    {
        bool canMove = stamina > MinimumToMove;
        
        if (canMove || moving)
        {
            if (!moving)
                moving = true;
            if (DebugIndication) Debug.Log("Standard Movement: -" + MoveDrain);
            ApplyDelta(-MoveDrain);
            return moving;
        }
        return false;
    }

    /// <summary>
    /// Standard Attack.
    /// </summary>
    public void Attack()
    {
        if (DebugIndication) Debug.Log("Standard Attack: -" + AttackDrain);
        ApplyDelta(-AttackDrain);
    }

    /// <summary>
    /// Recover stamina
    /// </summary>
    public void Recover()
    {
        if(stamina < MaxStamina && !crashed)
        {
            if (DebugIndication) Debug.Log("Standard Recovery: -" + StandardRestore);
            ApplyDelta(StandardRestore);
        }
        else if (stamina < MaxStamina && crashed)
        {
            if (DebugIndication) Debug.Log("Crashed Recovery: -" + CrashedRestore);
            ApplyDelta(CrashedRestore);
        }
    }

    /// <summary>
    /// Apply Change to Stamina.
    /// </summary>
    /// <param name="delta">Change to make to stamina.</param>
    public void ApplyDelta(int delta)
    {
        // Apply Delta
        stamina += delta;
        if (DebugValues) Debug.Log("Stamina Changed: " + delta + " Added, " + stamina + " Total.");

        // Check Upper Limit
        if (stamina >= MaxStamina)
        {
            if(DebugIndication) Debug.Log("Stamina Full.");
            stamina = MaxStamina;
            crashed = false;
        }

        // Check Lower Limit
        if (stamina <= 0)
        {
            if (DebugIndication) Debug.Log("Stamina Empty.");
            stamina = 0;
            crashed = true;
            moving = false;
        }
    }
}
