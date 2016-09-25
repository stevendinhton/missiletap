using UnityEngine;
using System.Collections;

// Used to control the fadeout of interceptor(player) missiles before they are destroyed
// Also destroys the game object
public class FadeOut : MonoBehaviour {
    public float fadeSpeed;     // How much the color will fade

    public void Fade()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("FadeAnimation");
    }

    Color GetColor()
    {
        return gameObject.GetComponent<TrailRenderer>().material.color;
    }

	IEnumerator FadeAnimation()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.clear;
        while (gameObject.GetComponent<TrailRenderer>().material.color.a > 0)
        {
            Color old = GetColor();
            Color faded = new Color(old.r, old.g, old.b, old.a - fadeSpeed * Time.deltaTime);

            //gameObject.GetComponent<Renderer>().material.color = faded;
            gameObject.GetComponent<TrailRenderer>().material.color = faded;
            yield return null;
        }
        Destroy(gameObject);
    }
}
