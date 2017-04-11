using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitWithEnemy : MonoBehaviour {

    public StaminaBar staminaBar;

	void OnTriggerEnter2D(Collider2D theObject)
    {
        //if an enemy hits the attack area it is destroyed
        if (theObject.CompareTag("enemy"))
        {
            staminaBar.attack();
            Destroy(theObject.gameObject);
        }
    }
}
