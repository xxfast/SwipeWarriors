using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingBehavior : MonoBehaviour {

	public float attackFrequency = 1;
	public int attackDamage = 1;
	public string attackAnyoneFlagged;

	public float time;
	public bool isAllowedToAttack = false;

	void Start(){
		time = attackFrequency;
	}

	void Update () {
		time -= Time.deltaTime;
		if ((time <= 0)) {
			isAllowedToAttack = true;
			time = attackFrequency;
		} else {
			isAllowedToAttack = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(isAllowedToAttack){
			if(collision.gameObject.CompareTag(attackAnyoneFlagged)){
				Health health;
				if(health = collision.gameObject.GetComponent<Health>()){
					health.DealDamage (attackDamage);
				}
			}
		}
	}
}
