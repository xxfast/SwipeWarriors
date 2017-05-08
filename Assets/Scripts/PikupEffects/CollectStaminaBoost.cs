using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStaminaBoost : MonoBehaviour {
    // Base Variables
    [Header("Base Variables:")]
    public int StaminaRecoveryAmount;

    /// <summary>
    /// Called on item collection.
    /// </summary>
    /// <param name="entity"></param>
    public void OnCollect(GameObject entity)
    {
        entity.GetComponent<Stamina>().ApplyDelta(StaminaRecoveryAmount);
        Destroy(this.gameObject);
    }
}
