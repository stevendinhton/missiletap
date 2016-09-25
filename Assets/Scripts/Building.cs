using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        StartCoroutine("fall");
    }

    IEnumerator fall()
    {
        while(true)
        {
            transform.Translate(Vector3.down * 0.1f * Time.deltaTime);
            yield return null;
        }
    }
}
