using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    public int stanima;
    //TODO: public int maxStamina;

    private bool crash;

	// Use this for initialization
	void Start () {
        crash = false;
        stanima = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Move is called each step of the players movement
    // Returns state of stamina bar (crash or not);
    public bool move()
    {
        Debug.Log(stanima);
        if(stanima > 0)
        {
            stanima--;
            return true;
        }
        else
        {
            crash = true;
            return false;
        }
    }
}
