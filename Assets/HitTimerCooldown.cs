using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTimerCooldown : MonoBehaviour {

    //This script handles the cooldown for when enemies get hit
    public Health healthBar;
    public float cooldownTime;

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
            }
            //Otherwise, countdown the time left
            else
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    started = false;
                    healthBar.isHit = false;
                }
            }
        }
	}
}
