using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {
    public string precedingText;
    public void UpdateScore()
    {
        gameObject.GetComponent<Text>().text = precedingText + PlayerPrefs.GetInt("Highscore");
    }
}
