using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSizeChange : MonoBehaviour {

    // Base Variables
    [Header("Base Variables:")]
    public float SetScale;
    public float DeltaScale;

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
            Vector3 scale = new Vector3(entity.transform.localScale.x * DeltaScale, entity.transform.localScale.y * DeltaScale);
            entity.transform.localScale = scale;
        }
        else
        {
            Vector3 scale = new Vector3(SetScale, SetScale);
            entity.transform.localScale = scale;
        }

        entity.SendMessage("SetScaleTimer", Duration);

        Destroy(this.gameObject);
    }
}
