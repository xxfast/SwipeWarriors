using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AttackingBehavior))]
public class RiskAversionBehavior : MonoBehaviour {
	
	public bool IsAbleToDefeatEnemy(GameObject enemy){
		float selfHealth = this.gameObject.GetComponent<Health> ().CurrentHealth;
		float enemyHealth = enemy.GetComponent<Health> ().CurrentHealth;
		int selfAttackDamage = this.gameObject.GetComponent<AttackingBehavior> ().attackDamage;
		float selfAttackFrequency = this.gameObject.GetComponent<AttackingBehavior> ().attackFrequency;
		int enemyAttackDamage = 1;
		if (enemy.GetComponent<OnHitWithEnemy> ())
			enemyAttackDamage = enemy.GetComponent<OnHitWithEnemy> ().damageAmount;
		else if (enemy.GetComponent<AttackingBehavior> ())
			enemyAttackDamage = enemy.GetComponent<AttackingBehavior> ().attackDamage;

		// TODO: Figure out the equation
		return (true);
	}

}
