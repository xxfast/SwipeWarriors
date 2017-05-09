using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDilation : MonoBehaviour {
    [Header("Base Variables:")]
    [SerializeField]
    private float standardGameSpeed;
    [SerializeField]
    private float currentDilation;
    [SerializeField]
    private float currentTime;
    [SerializeField]
    private bool dilating;

    private bool active;

    [Header("Settings:")]
    [Range(0.0f, 1.0f)]public float MaximumDilation;
    public float DilationTime;

    // Use this for initialization
    void Start () {
        standardGameSpeed = 1.0f;
        currentDilation = 1.0f;
        currentTime = -1.0f;
        dilating = false;
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
            if (currentTime > 0)
                updateTime();
	}

    /// <summary>
    /// Updates Time Dilation (dynamic)
    /// </summary>
    private void updateTime()
    {
        currentTime -= Time.deltaTime;

        if (currentTime > 0)
        {
            float delta = (standardGameSpeed - MaximumDilation) * (currentTime / DilationTime);
            if (dilating)
                Time.timeScale = MaximumDilation + delta;
            else
                Time.timeScale = standardGameSpeed - delta;
        }
        else
        {
            if (dilating)
                Time.timeScale = MaximumDilation;
            else
                Time.timeScale = standardGameSpeed;
        }
    }

    /// <summary>
    /// Toggles Time Dilation (Dynamic)
    /// </summary>
    public void ToggleDilation()
    {
        if (active)
        {
            currentTime = DilationTime;
            dilating = !dilating;
        }
    }

    /// <summary>
    /// Dilates Timescale (Static)
    /// </summary>
    public void DilateTime()
    {
        if (active)
            Time.timeScale = MaximumDilation;
    }

    /// <summary>
    /// Restores Timescale (Static)
    /// </summary>
    public void RestoreTime()
    {
        if(active)
            Time.timeScale = standardGameSpeed;
    }

    public void SetWin()
    {
        active = false;
    }

    public void SetLoss()
    {
        active = false;
    }
}
