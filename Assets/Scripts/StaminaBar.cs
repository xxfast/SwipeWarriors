using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    private int stamina;
    private int maxStamina;

    private int standardRestore;
    private int crashRestore;

    private bool crash;

	// Use this for initialization
	void Start () {
        crash = false;

        maxStamina = 500;
        standardRestore = 5;
        crashRestore = 1;

        stamina = 500;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Move is called each step of the players movement
    // Returns state of stamina bar (crash or not);
    public bool move()
    {
        Debug.Log(stamina);
        if(stamina > 0)
        {
            stamina--;
            return true;
        }
        else
        {
            crash = true;
            return false;
        }
    }

    /// <summary>
    /// Recovers stamina by n;
    /// </summary>
    public void recover()
    {
        // Standard recovery
        if (stamina < maxStamina && !crash)
        {
            stamina += standardRestore;
            Debug.Log(stamina);
        }
        // Crash Debuff recovery
        else if (stamina < maxStamina && crash)
        {
            stamina += crashRestore;
            Debug.Log(stamina);
        }

        if (stamina == maxStamina)
            crash = false;
    }
}
