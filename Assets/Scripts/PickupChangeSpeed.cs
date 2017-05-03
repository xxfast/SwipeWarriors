using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupChangeSpeed : MonoBehaviour {

    public float SetSpeed;
    public float ScaleSpeed;

    public int Duration;

    public bool Stakable;
    public bool DebugMessage;

    // executes on collect. (called by player)
    public void onCollect(GameObject gameObject)
    {
        if (DebugMessage)
            Debug.Log("Changing Speed");

        if (Stakable)
        {
            gameObject.GetComponent<PathMovement>().speed = gameObject.GetComponent<PathMovement>().speed * ScaleSpeed;
        }
        else
        {
            gameObject.GetComponent<PathMovement>().speed = SetSpeed;
        }

        gameObject.SendMessage("SetSpeedRevertTimer", Duration);

        Destroy(this.gameObject);
    }
}
