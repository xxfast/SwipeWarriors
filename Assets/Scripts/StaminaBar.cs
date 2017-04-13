using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    public int stamina;
    public int maxStamina;

    public int standardRestore;
    public int crashRestore;

    public int attackDrain;
    public int moveDrain;

    private bool crash;

    public bool debug;

	// Use this for initialization
	void Start () {
        crash = false;
	}

    // Move is called each step of the players movement
    // Returns if player can move;
    public bool move()
    {
        if (debug)
            Debug.Log("Standard Restore: ");
        applyDelta(-moveDrain);
        return !crash; // Can move it not crashed
    }

    // Recovers stamina by n;
    public void recover()
    {
        // Standard recovery
        if (stamina < maxStamina && !crash)
        {
            if (debug)
                Debug.Log("Standard Restore: ");
            applyDelta(standardRestore);
        }
        // Crash Debuff recovery
        else if (stamina < maxStamina && crash)
        {
            if (debug)
                Debug.Log("Crashed Restore: ");
            applyDelta(crashRestore);
        }
    }

    // Drains stamina by n when called.
    public void attack()
    {
        if(debug)
            Debug.Log("Attacked: ");
        applyDelta(-attackDrain);
    }

    // Changes stamina by delta
    public void applyDelta(int delta)
    {
        // Alter stamina
        stamina += delta;
        if (debug)
            Debug.Log(stamina);

        // Check limits
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
            crash = false;
        }
        
        if(stamina <= 0)
        {
            stamina = 0;
            crash = true;
        }
    }
}
