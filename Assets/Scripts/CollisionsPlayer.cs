using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CollisionsPlayer : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private Text gameText;

    // Settings
    [Header("Settings:")]
    public string WinText;
    public string LossText;

    // Flags
    [Header("Flags:")]
    public bool DebugMessages;

    // Use this for initialization
    void Start () {
        gameText = GameObject.Find("GameText").GetComponent<Text>();
        gameText.text = "";
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //When an enemy collides with the player, the game is over
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (DebugMessages) Debug.Log("Collision With Enemy");
            gameText.text = LossText;
            Time.timeScale = 0;
        }

        //Collect pickups on collisiion
        if (col.gameObject.CompareTag("Pickup"))
        {
            if (DebugMessages) Debug.Log("Collision With Pickup");
            col.gameObject.SendMessage("OnCollect", this.gameObject);
        }
    }
}
