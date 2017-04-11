using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitWithEnemy : MonoBehaviour {

	public string with = "enemy";
	public int damageAmount = 2;


	void OnTriggerEnter2D(Collider2D theObject)
    {
        //if an enemy hits the attack area it is destroyed
		if (theObject.CompareTag(with))
        {
			theObject.gameObject.GetComponent<Health> ().DealDamage (damageAmount);
        }
    }
}
