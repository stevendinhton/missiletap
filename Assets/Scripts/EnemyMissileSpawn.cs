using UnityEngine;
using System.Collections;

public class EnemyMissileSpawn : MonoBehaviour {
    private float spawnLocation;    // the randomly generated x coordinate where the enemy missile will spawn
    public float spawnRange;        // how far (+ or - in x coordinate) the randomly placed missile could be placed
    public float spawnHeight;       // how high up the enemy missiles will spawn


	// Use this for initialization
	void Start () {
        spawnLocation = Random.Range(-spawnRange, spawnRange);
        gameObject.transform.position = new Vector3(spawnLocation, spawnHeight, transform.position.z);
	}
	
}
