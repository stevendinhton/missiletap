using UnityEngine;
using System.Collections;

public class PixelSpawner : MonoBehaviour {
    public GameObject pixel;
    public Vector3 bottomLeft;
    public int height;
    public int length;
    public float distance;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Instantiate(pixel, bottomLeft + Vector3.right * distance * i + Vector3.up * distance * j, pixel.transform.rotation);
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
