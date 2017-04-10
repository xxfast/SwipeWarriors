using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    private int stamina;
    private int maxStamina;

    private int standardRestore;

    private bool crash;

	// Use this for initialization
	void Start () {
        crash = false;

        maxStamina = 1000;
        standardRestore = 2;

        stamina = 1000;
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
        if (stamina < maxStamina)
        {
            Debug.Log(stamina);
            stamina += standardRestore;
        }

        if (stamina == maxStamina)
            crash = false;
    }
}
