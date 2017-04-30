using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelay : MonoBehaviour {

    public float timeDelay = 0.2f;

	
	// Update is called once per frame
	void Update () {
        //When the player is moving then time should slow down
		if (Input.GetMouseButton(0))
        {
            Time.timeScale = timeDelay;
        }
        //Otherwise, return it to normal
        else
        {
            Time.timeScale = 1;
        }
	}
}
