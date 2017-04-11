using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    public int stamina;
    public int maxStamina;

    public int standardRestore;
    public int crashRestore;

    public int attackDrain;

    private bool crash;

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

    // Recovers stamina by n;
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

    // Drains stamina by n when called.
    public void attack()
    {
        Debug.Log("Attacked: " + stamina);

        if (stamina > 0)
            stamina -= attackDrain;
    }
}
