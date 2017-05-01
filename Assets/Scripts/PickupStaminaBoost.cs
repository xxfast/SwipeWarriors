using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStaminaBoost : MonoBehaviour {
    //variables
    public int recoveryAmount;

    // executes on collect. (called by player)
    public void onCollect(GameObject gameObject)
    {
        gameObject.GetComponent<StaminaBar>().applyDelta(recoveryAmount);
    }
}
