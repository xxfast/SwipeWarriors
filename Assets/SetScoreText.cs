using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreText : MonoBehaviour {

    public string ScorePrefix;

    private int score;

	// Update is called once per frame
	void Update () {
        int currentScore = GameObject.Find("ScoreKeeper").GetComponent<Score>().CurrentScore;
        if (score != currentScore) // score has changed update.
        {
            score = currentScore;

            this.gameObject.GetComponent<Text>().text = ScorePrefix + ' ' + score;
        }
    }
}
