using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionsPlayer : MonoBehaviour {
    // Game Object Refernces
    public Text gameText;

    public string gameOverText;

    public bool debug;


	// Use this for initialization
	void Start () {
        gameText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //When an enemy collides with the player, the game is over
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (debug)
                Debug.Log("Collision with Enemy");
            gameText.text = gameOverText;
            Time.timeScale = 0;
        }

        //Collected Pickup
        if (col.gameObject.CompareTag("Pickup"))
        {
            if (debug)
                Debug.Log("Pickup Collected");
            col.gameObject.SendMessage("onCollect");
            Destroy(col.gameObject);
        }
    }
}
