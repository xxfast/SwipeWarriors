using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitWithEnemy : MonoBehaviour {

    public string with = "enemy";
    public int damageAmount = 2;
    public StaminaBar staminaBar;

    public int DamageScore;


	void OnTriggerEnter2D(Collider2D theObject)
    {
        //if an enemy hits the attack area it is destroyed
		if (theObject.CompareTag(with))
        {
            theObject.gameObject.GetComponent<Health> ().DealDamage (damageAmount);
            staminaBar.attack();
            try { GameObject.Find("ScoreKeeper").SendMessage("Add", DamageScore); } catch { }
            Destroy(this.gameObject);
        }
    }
}
