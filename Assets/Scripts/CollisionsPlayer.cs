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
    [Header("Settings")]
    public string WinText;
    public string LossText;

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
            gameText.text = LossText;
            Time.timeScale = 0;
        }
    }
}
