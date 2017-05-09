using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAndEnemyContact : MonoBehaviour {

    public Text LossText;

    void Start()
    {
        LossText.text = "";
    }

	void OnCollisionEnter2D(Collision2D theCollider)
    {
        //When an enemy collides with the player, the player gets hit
        if (theCollider.gameObject.CompareTag("enemy"))
        {
            //check if the enemy is hit, if not then deal damage to the player
            Health healthBar = (Health)theCollider.gameObject.GetComponent(typeof(Health));
            if (!healthBar.isHit)
            {
                LossText.text = "YOU LOSE!";
                Time.timeScale = 0;
            }
        }
    }
}
