using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWhileMoving : MonoBehaviour {

    public StaminaBar staminaBar;
    public float spinAccelerator;
    public float rotationAmount;
    private float spinModifier = 0;
	
	// Update is called once per frame
	void Update () {
        //While moving, the player will spin faster, until it reaches its max rotation speed
		if (staminaBar.moving)
        {
            //The spinModifer variable makes
            spinModifier += spinAccelerator * Time.deltaTime;
            if (spinModifier > 1)
            {
                spinModifier = 1;
            }            
        }
        //Otherwise the player will spin slower, until the player stops rotating
        else
        {
            spinModifier -= spinAccelerator * Time.deltaTime;
            if (spinModifier < 0)
            {
                spinModifier = 0;
            }
        }

        //Then rotate it!
        this.transform.Rotate(0, 0, rotationAmount * Time.deltaTime * spinModifier);
    }
}
