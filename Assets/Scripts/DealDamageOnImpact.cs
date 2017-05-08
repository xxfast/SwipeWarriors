using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnImpact : MonoBehaviour {

	public int damage = 10;
	public string damageObjectsTagged = "enemy";
    public int DamageScore;

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag==damageObjectsTagged){
			collision.gameObject.GetComponent<Health> ().DealDamage (damage);
            GameObject.Find("ScoreKeeper").SendMessage("Add", DamageScore);
        }
	}
}
