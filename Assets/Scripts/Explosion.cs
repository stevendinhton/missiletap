using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    private float startTime;
    private float endTime;
    private float currentSize;
    public float despawnDelay;
    public float explosionSize;
    public float fadeSpeed;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        endTime = startTime + despawnDelay;
        currentSize = 0.1f;
        StartCoroutine("Explode");
    }
	
	// Update is called once per frame
	void Update () {

        /*Color fade;
        Color original = gameObject.GetComponent<Renderer>().material.color;
        fade.r = original.r;
        fade.g = original.g;
        fade.b = original.b;
        fade.a = original.a;

        if (Time.time > endTime)
        {
            fade.a = Mathf.Clamp(fade.a - fadeSpeed * Time.deltaTime, 0f, 1f);
            gameObject.GetComponent<Renderer>().material.color = fade;
            if (fade.a == 0)
            {
                Destroy(gameObject);
            }
            else if(fade.a < 0.5)
            {
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
        }
        else
        {
            //transform.localScale = Vector3.Scale(transform.localScale, Vector3.one * explosionSize);
            transform.localScale = 0.5f * Vector3.one * Mathf.Log(1 + currentSize, 2);
            currentSize += explosionSize * Time.deltaTime;
        }*/
	}

    IEnumerator Explode()
    {
        int explosionStage = 0; //0, 1 and 2
        while (explosionStage == 0)
        {
            transform.localScale = 0.5f * Vector3.one * Mathf.Log(1 + currentSize, 2);
            currentSize += explosionSize * Time.deltaTime;
            if (Time.time > endTime)
            {
                endTime += despawnDelay;
                explosionStage = 1;
                currentSize = 0;
            }
            yield return null;
        }
        while (explosionStage == 1)
        {
            transform.localScale = transform.localScale * (1 / (0.1f*currentSize + 1));
            currentSize += explosionSize * Time.deltaTime;
            if (transform.localScale.x <= Vector3.one.x * 0.05f)
            {
                explosionStage = 2;
                Destroy(gameObject);
            }
            yield return null;
        }
    }
}
