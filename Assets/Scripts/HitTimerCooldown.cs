using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTimerCooldown : MonoBehaviour {

    //This script handles the cooldown for when enemies get hit
    public Health healthBar;
    public float cooldownTime;
    public int knockbackForce;
    public GameObject knockbackFrom;

    private float timeLeft = 0.0f;
    private bool started = false;

	// Update is called once per frame
	void Update () {
		if (healthBar.isHit)
        {
            //If the cooldown has not started, then start the cooldown
            if (!started)
            {
                started = true;
                timeLeft = cooldownTime;
                //Turns the hit object red
                this.GetComponent<SpriteRenderer>().color = new Color(128, 0, 0);
                //Knockback force added here
                Vector2 knockBack = this.transform.position - knockbackFrom.transform.position;
                knockBack.Normalize();
                knockBack *= knockbackForce;

                this.GetComponent<Rigidbody2D>().AddForce(knockBack);
            }
            //Otherwise, countdown the time left
            else
            {
                timeLeft -= Time.deltaTime;
                //When the cooldown is finished, the enemy is stopped being hit
                if (timeLeft <= 0)
                {
                    started = false;
                    healthBar.isHit = false;
                    //Turns the object back to its normal color
                    this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                }
            }
        }
	}
}
