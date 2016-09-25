using UnityEngine;
using System.Collections;

public class SpawnBuildings : MonoBehaviour {
    public GameObject building;
    public float minSpacing;
    public float maxSpacing;
    public float minHeight;
    public float maxHeight;
    public Vector3 startLocation;
    public Vector3 direction;
    public float maxX;
    public float minX;

	// Use this for initialization
	void Start () {
        Vector3 lastLocation = new Vector3(startLocation.x, startLocation.y, startLocation.z);
        
	    while(lastLocation.x >= minX && lastLocation.x <= maxX)
        {
            lastLocation += direction * Random.Range(minSpacing, maxSpacing);
            GameObject spawned = Instantiate(building, lastLocation, building.transform.rotation) as GameObject;
            spawned.transform.localScale += Vector3.up * Random.Range(minHeight, maxHeight);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

}
