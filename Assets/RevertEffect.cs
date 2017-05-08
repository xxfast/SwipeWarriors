using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertEffect : MonoBehaviour {
    // Base Variables
    [Header("Scale Variables:")]
    [SerializeField]
    private Vector3 initalScale;
    [SerializeField]
    private float scaleTime;

    [Header("Speed Variables:")]
    [SerializeField]
    private float initalSpeed;
    [SerializeField]
    private float speedTime;


    // Use this for initialization
    void Start () {
        initalScale = this.gameObject.transform.localScale;

        if (this.gameObject.CompareTag("Player")) // Player Speed from Path Movement
            initalSpeed = this.gameObject.GetComponent<PathMovement>().Speed;
        else if (this.gameObject.CompareTag("Enemy"))
            initalSpeed = this.gameObject.GetComponent<FollowTarget>().FollowSpeed;
        else
            initalSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (scaleTime > 0)
            checkScaleRevert();
        if (speedTime > 0)
            checkSpeedRevert();
	}

    /// <summary>
    /// updates scale time and reverts if timer complete.
    /// </summary>
    private void checkScaleRevert()
    {
        scaleTime -= Time.deltaTime;

        if (!(scaleTime > 0))
            RevertScale();
    }

    /// <summary>
    /// Reverts scale if called.
    /// </summary>
    public void RevertScale()
    {
        this.gameObject.transform.localScale = initalScale;
    }

    /// <summary>
    /// Sets the length of the scale timer
    /// </summary>
    /// <param name="length">Lenth of time in seconds.</param>
    public void SetScaleTimer(float length)
    {
        scaleTime = length;
    }

    /// <summary>
    /// updates scale time and reverts if timer complete.
    /// </summary>
    private void checkSpeedRevert()
    {
        speedTime -= Time.deltaTime;

        if (!(speedTime > 0))
            RevertSpeed();
    }

    /// <summary>
    /// Reverts scale if called.
    /// </summary>
    public void RevertSpeed()
    {
        if (this.gameObject.CompareTag("Player")) // Player Speed from Path Movement
            this.gameObject.GetComponent<PathMovement>().Speed = initalSpeed;
        else if (this.gameObject.CompareTag("Enemy")) // Enemy Speed from Follow Target
            this.gameObject.GetComponent<FollowTarget>().FollowSpeed = initalSpeed;
    }

    /// <summary>
    /// Sets the length of the scale timer
    /// </summary>
    /// <param name="length">Lenth of time in seconds.</param>
    public void SetSpeedTimer(float length)
    {
        scaleTime = length;
    }
}
