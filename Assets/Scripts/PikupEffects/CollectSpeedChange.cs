using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpeedChange : MonoBehaviour {

    // Base Variables
    [Header("Base Variables:")]
    public float SetSpeed;
    public float DeltaSpeed;

    [Header("Settings:")]
    public int Duration;

    public bool Stackable;

    /// <summary>
    /// Called on item collection.
    /// </summary>
    /// <param name="entity"></param>
    public void OnCollect(GameObject entity)
    {
        if (Stackable)
        {
            entity.GetComponent<PathMovement>().Speed = entity.GetComponent<PathMovement>().Speed * DeltaSpeed;
        }
        else
        {
            entity.GetComponent<PathMovement>().Speed = SetSpeed;
        }

        entity.SendMessage("SetSpeedTimer", Duration);

        Destroy(this.gameObject);
    }
}
