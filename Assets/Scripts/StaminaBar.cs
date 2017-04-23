using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    public int stamina;
    public int maxStamina;
    public int minimumStamina;

    public int standardRestore;
    public int crashRestore;

    public int attackDrain;
    public int moveDrain;

    private bool crash;
    public bool moving;

    public bool debugIndicators;
    public bool debugValues;

	// Use this for initialization
	void Start () {
        crash = false;
        moving = false;
	}

    // Move is called each step of the players movement
    // Returns if player can move;
    public bool move()
    {
        bool canMove = stamina >= minimumStamina; // Player can move if stamina is greater than the minimum stamina
        if (debugIndicators)
            Debug.Log("Standard Move: - " + moveDrain);
        if (canMove || moving)
            applyDelta(-moveDrain);
        return canMove || moving;
    }

    // Recovers stamina by n;
    public void recover()
    {
        // Standard recovery
        if (stamina < maxStamina && !crash)
        {
            if (debugIndicators)
                Debug.Log("Standard Restore: +" + standardRestore);
            applyDelta(standardRestore);
        }
        // Crash Debuff recovery
        else if (stamina < maxStamina && crash)
        {
            if (debugIndicators)
                Debug.Log("Crashed Restore: +" + crashRestore);
            applyDelta(crashRestore);
        }
    }

    // Drains stamina by n when called.
    public void attack()
    {
        if(debugIndicators)
            Debug.Log("Attacked: -" + attackDrain);
        applyDelta(-attackDrain);
    }

    // Changes stamina by delta
    public void applyDelta(int delta)
    {
        // Alter stamina
        stamina += delta;
        if (debugValues)
            Debug.Log(stamina);

        // Check limits
        if (stamina >= maxStamina)
        {
            if (debugIndicators)
                Debug.Log("Stamina Filled");
            stamina = maxStamina;
            crash = false;
        }
        
        if(stamina <= 0)
        {
            if (debugIndicators)
                Debug.Log("Stamina Crashed");
            stamina = 0;
            crash = true;
            moving = false;
        }
    }
}
