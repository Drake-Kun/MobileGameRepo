using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScriptBeta : MonoBehaviour {

    
    public int enemiesLeft = 10;
    public GameObject enemy;
    public GameObject spawner;
    public float spawnTimer = 5.0f;
    private Vector3 spawnPosition;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Spawn", spawnTimer, spawnTimer);

    }

    void Spawn()
    {
        spawnPosition.x = spawner.transform.position.x;
        spawnPosition.y = spawner.transform.position.y;

        Instantiate(enemy);
        enemiesLeft--;
    }

   
}
