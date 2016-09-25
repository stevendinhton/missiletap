using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
    public Camera cam;
    public GameManager gm;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter()
    {
        cam.GetComponent<CameraShake>().Shake();
        gm.lose();
    }
}
