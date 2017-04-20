using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStaminaBoost : MonoBehaviour {
    //refernces
    public StaminaBar staminaBar;

    //variables
    public int recoveryAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // executes on collect. (called by player)
    public void onCollect()
    {
        staminaBar.applyDelta(recoveryAmount);
    }
}
