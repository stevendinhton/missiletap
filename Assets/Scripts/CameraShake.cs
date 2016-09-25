using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public float intensity; // how strong the shakes are
    public float duration;  // how long the shakes will last
    private Vector3 orig;   // the original location of the camera
    private float strength; // the current strength of the shake
    private bool isShaking; // whether or not the camera is currently shaking

	// Use this for initialization
	void Start () {
        orig = transform.position;
        strength = 0;
        isShaking = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Shake ()
    {
        if(!isShaking)
        {
            StartCoroutine("ShakeAnimation");
        }
    }

    IEnumerator ShakeAnimation()
    {
        isShaking = true;
        float start = Time.time;
        float timeSinceStart = 0;

        while (timeSinceStart < duration)
        {
            timeSinceStart = Time.time - start;

            // parabolic function
            // roots at (0, 0) and (duration, 0), intensity is vertical stretch
            strength = (-intensity) * (timeSinceStart) * (timeSinceStart - duration);

            Vector3 newLocation = new Vector3(
                Random.Range(orig.x - strength, orig.x + strength),
                Random.Range(orig.y - strength, orig.y + strength),
                orig.z);

            transform.position = newLocation;
            //print("shaken");
            yield return null;
        }
        transform.position = orig;
        isShaking = false;
    }
}
