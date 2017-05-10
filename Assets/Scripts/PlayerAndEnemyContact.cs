using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAndEnemyContact : MonoBehaviour {

    public Text LossText;

    public int CollectionScore;

    void Start()
    {
        LossText.text = "";
    }

	void OnCollisionEnter2D(Collision2D theCollider)
    {
        //When an enemy collides with the player, the game is over
        if (theCollider.gameObject.CompareTag("enemy"))
        {
            LossText.text = "YOU LOSE!";
            Time.timeScale = 0;
        }

        if (theCollider.gameObject.CompareTag("pickup"))
        {
            Debug.Log("Collided with Pickup");
            theCollider.gameObject.SendMessage("onCollect", this.gameObject);
            try { GameObject.Find("ScoreKeeper").SendMessage("Add", CollectionScore); } catch { }
        }
    }
}
