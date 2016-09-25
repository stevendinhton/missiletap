using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject interceptors; // InterceptorManager game object
    public GameObject enemies;      // EnemyManager game object
    public GameObject indicator;    // Target Indicator object that is spawned at click location
    public GameObject scoreText;    // The score text UI element
    public GameObject loseScreen;   // 
    public Camera cam;              // The main game camera
    private bool playing;           // Whether or not the game is currently playing
    public bool canLose;            // Whether or not the game will end on the default losing condition
    private int score;
    

	// Use this for initialization
	void Start ()
    {
        score = 0;
        playing = true;
        interceptors.SetActive(true);
        enemies.SetActive(true);
        StartCoroutine("tickingScore");
        if(!PlayerPrefs.HasKey("Highscore"))
            clearScore();
    }

    public void clearScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }

    public void restartGame()
    {
        if(!playing)
        {
            playing = true;
            interceptors.SetActive(true);
            interceptors.GetComponent<InterceptorManager>().resume();
            enemies.SetActive(true);
            StartCoroutine("tickingScore");
        }
    }

    public void StopGame()
    {
        playing = false;
        interceptors.SetActive(false);
        enemies.SetActive(false);
    }

    public bool Playing()
    {
        return playing;
    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0) && playing)
        {
            Vector3 targetLocation = Vector3.ProjectOnPlane(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition),Vector3.back);

            if (interceptors.GetComponent<InterceptorManager>().ready())
            {
                Instantiate(indicator, targetLocation, indicator.transform.rotation);
            }

            interceptors.GetComponent<InterceptorManager>().fire(targetLocation);
            
        }
	}

    public int getScore()
    {
        return score;
    }

    public void addScore()
    {
        score++;
        scoreText.GetComponent<ScoreText>().updateScore(score);
    }

    public void resetScore()
    {
        score = 0;
        scoreText.GetComponent<ScoreText>().updateScore(score);
    }

    public void lose()
    {
        if(canLose)
        {
            StopGame();
            loseScreen.SetActive(true);
            updateHighScore(score);
            loseScreen.GetComponentInChildren<HighScore>().UpdateScore();
            //loseScreen.GetComponentInChildren<CurrentScore>().UpdateScore(score);
        }
    }

    public void updateHighScore(int score)
    {
        if(score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public void destroyAllMissiles()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("missile");

        for (int i = 0; i < missiles.Length; ++i)
            Destroy(missiles[i]);
    }

    IEnumerator tickingScore()
    {
        while(playing)
        {
            yield return new WaitForSeconds(5);
            if(playing)
            addScore();
        }
    }
}
