using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertSize : MonoBehaviour {

    private Vector3 initalSize;

    [SerializeField]
    private float time;

	// Use this for initialization
	void Start () {
        initalSize = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 0)
            checkRevert();
	}

    private void checkRevert()
    {
        time -= Time.deltaTime;

        if(!(time > 0))
        {
            this.gameObject.transform.localScale = initalSize;
        }
    }

    /// <summary>
    /// Sets the revert timer for size
    /// </summary>
    /// <param name="time">Time in seconds</param>
    public void SetSizeRevertTimer(int time)
    {
        this.time = time;
    }
}
