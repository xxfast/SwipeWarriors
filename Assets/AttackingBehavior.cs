using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingBehavior : MonoBehaviour {

	public float attackFrequency = 1;
	private int attackDamage = 1;
	public string attackAnyoneFlagged;

	private float time;
	private float isAllowedToAttack = false;

	void Start(){
		time = attackFrequency;
	}

	void Update () {
		time -= Time.deltaTime;
		isAllowedToAttack = (time <= 0);
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
