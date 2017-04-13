using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitWithEnemy : MonoBehaviour {

  public int damageAmount = 2;
  public StaminaBar staminaBar;
	void OnTriggerEnter2D(Collider2D col)
    {
        //if an enemy hits the attack area it is destroyed
		if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Health> ().DealDamage (damageAmount);
          staminaBar.attack();
        }
    }
}
