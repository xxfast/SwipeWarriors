using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingBehavior : MonoBehaviour {

	//Amount of damage dealt on one hit
	public int attackDamage = 1;
	//Frequency of attack
	public float attackFrequency = 1;
	//Tag of target
	public string attackAnyoneFlagged;

	private float time;
	public bool isAllowed = false;

	void Start(){
		time = attackFrequency;
	}

	void Update(){
		time -= Time.deltaTime;
		isAllowed = (time <= 0);
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (isAllowed) {
			if (collision.gameObject.CompareTag (attackAnyoneFlagged)) {
				Health health;
				if (health = collision.gameObject.GetComponent<Health> ()) {
					health.DealDamage (attackDamage);
				}
			}
			isAllowed = false;
			Start ();
		}
	}

}
