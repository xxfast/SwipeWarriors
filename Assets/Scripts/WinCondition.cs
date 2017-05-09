using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.gameObject.GetComponent<HordeSpawner>().enabled
            && GameObject.FindGameObjectWithTag("enemy") == null) // No Waves Left
        {
            GameObject.Find("LossText").GetComponent<Text>().text = "You Win!";
        }
	}
}
