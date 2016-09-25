using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {
    public string precedingText;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Text>().text = "0";

    }

    public void updateScore(int newScore)
    {
        gameObject.GetComponent<Text>().text = precedingText + newScore;
    }
}
