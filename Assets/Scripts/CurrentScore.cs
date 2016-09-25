using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentScore : MonoBehaviour {

    // Use this for initialization
    public string precedingText;
    public void UpdateScore(int score)
    {
        gameObject.GetComponent<Text>().text = precedingText + score;
    }
}
