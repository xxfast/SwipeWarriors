using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupChangeSize : MonoBehaviour {

    public float SetSize;
    public float ScaleSize;

    public int Duration;

    public bool Stakable;
    public bool DebugMessage;

    // executes on collect. (called by player)
    public void onCollect(GameObject gameObject)
    {
        if (DebugMessage)
            Debug.Log("Changing Size");

        if(Stakable)
        {
            Vector3 scale = new Vector3(gameObject.transform.localScale.x * ScaleSize, gameObject.transform.localScale.y * ScaleSize);
            gameObject.transform.localScale = scale;
        }
        else
        {
            Vector3 scale = new Vector3(SetSize, SetSize);
            gameObject.transform.localScale = scale;
        }

        gameObject.SendMessage("SetSizeRevertTimer", Duration);

        Destroy(this.gameObject);
    }
}
