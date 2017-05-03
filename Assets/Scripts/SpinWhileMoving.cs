using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWhileMoving : MonoBehaviour {

    public StaminaBar staminaBar;
	
	// Update is called once per frame
	void Update () {
        //While moving, the player will spin
		if (staminaBar.moving)
        {
            this.transform.Rotate(0, 0, 720 * Time.deltaTime);
        }
	}
}
