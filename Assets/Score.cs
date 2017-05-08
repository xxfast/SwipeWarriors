using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int CurrentScore;

	// Use this for initialization
	void Start () {
        CurrentScore = 0;
	}

    /// <summary>
    /// Adds to current score;
    /// </summary>
    /// <param name="delta">Amount to add</param>
    public void Add(int delta)
    {
        ApplyDelta(delta);
    }

    /// <summary>
    /// Takes from current score; (will not go below zero)
    /// </summary>
    /// <param name="delta">Amount to subtract</param>
    public void Subtract(int delta)
    {
        if (CurrentScore >= delta)
            ApplyDelta(-delta);
        else
            CurrentScore = 0;
    }

    private void ApplyDelta(int delta)
    {
        CurrentScore += delta;
    }
}
