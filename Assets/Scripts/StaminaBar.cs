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
	
	// Update is called once per frame
	void Update () {
		
	}

    // Move is called each step of the players movement
    // Returns state of stamina bar (crash or not);
    public bool move()
    {
        if (debug)
            Debug.Log("Standard Restore: ");
        delta(-moveDrain);
        return crash;
    }

    // Recovers stamina by n;
    public void recover()
    {
        // Standard recovery
        if (stamina < maxStamina && !crash)
        {
            if (debug)
                Debug.Log("Standard Restore: ");
            delta(standardRestore);
        }
        // Crash Debuff recovery
        else if (stamina < maxStamina && crash)
        {
            if (debug)
                Debug.Log("Crashed Restore: ");
            delta(crashRestore);
        }
    }

    // Drains stamina by n when called.
    public void attack()
    {
        if(debug)
            Debug.Log("Attacked: ");
        delta(-attackDrain);
    }

    // Changes stamina by delta
    public void delta(int delta)
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
