using UnityEngine;
using System.Collections;

public class Pixel : MonoBehaviour {
    private bool triggered;
    public float speed;
    public float highestAlpha;

	// Use this for initialization
	void Start ()
    {
        triggered = false;
        StartCoroutine("FadeAnimation");
	}

    void OnTriggerExit ()
    {
        triggered = false;
    }

    void OnTriggerStay ()
    {
        triggered = true;
        Color current = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = AddAlpha(current, speed * Time.deltaTime);
    }

    Color AddAlpha(Color col, float increase)
    {
        return new Color(col.r,col.g,col.b, Mathf.Clamp(col.a + increase, 0f, highestAlpha));
    }

    IEnumerator FadeAnimation ()
    {
        while(!triggered)
        {
            Color current = gameObject.GetComponent<Renderer>().material.color;
            if(!triggered)
            {
                gameObject.GetComponent<Renderer>().material.color = AddAlpha(current, -speed * Time.deltaTime);
            }
            yield return null;
        }
    }
    
    IEnumerator FadeOut ()
    {
        while(triggered)
        {
            float currentA = gameObject.GetComponent<Renderer>().material.color.a;
            yield return null;
            if (currentA == gameObject.GetComponent<Renderer>().material.color.a)
            {
                triggered = false;
            }
        }
    }
}
