using UnityEngine;
using System.Collections;

public class SpawnEnemyMissiles : MonoBehaviour {
    public float spawnDelay;
    public GameObject missile;
    private float time;
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time >= spawnDelay)
        {
            Instantiate(missile);
            time = 0f;
        }
	}
}
