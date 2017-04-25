using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameText : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    [SerializeField]
    private Text gameText;

    // Settings
    [Header("Settings:")]
    public string WinText;
    public string LossText;

    // Use this for initialization
    void Start()
    {
        gameText = GameObject.Find("GameText").GetComponent<Text>();
        gameText.text = "";
    }
	
	public void SetWin()
    {
        gameText.text = WinText;
        Time.timeScale = 0;
    }

    public void SetLoss()
    {
        gameText.text = LossText;
        Time.timeScale = 0;
    }
}
