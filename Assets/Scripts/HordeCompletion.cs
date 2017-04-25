using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HordeCompletion : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!this.gameObject.GetComponent<HordeSpawner>().enabled 
            && GameObject.FindGameObjectWithTag("enemy") == null) // No Waves Left & All Enemies Defeated
        {
            GameObject.Find("DirectorGame").SendMessage("SetWin");
        }
    }
}
