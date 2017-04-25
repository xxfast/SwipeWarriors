using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CollisionsPlayer : MonoBehaviour {
    // Flags
    [Header("Flags:")]
    public bool DebugMessages;

    void OnCollisionEnter2D(Collision2D col)
    {
        //When an enemy collides with the player, the game is over
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (DebugMessages) Debug.Log("Collision With Enemy");
            GameObject.Find("DirectorGame").SendMessage("SetLoss");
        }

        //Collect pickups on collisiion
        if (col.gameObject.CompareTag("Pickup"))
        {
            if (DebugMessages) Debug.Log("Collision With Pickup");
            col.gameObject.SendMessage("OnCollect", this.gameObject);
        }
    }
}
