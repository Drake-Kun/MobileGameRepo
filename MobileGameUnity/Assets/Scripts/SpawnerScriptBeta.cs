using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScriptBeta : MonoBehaviour {

    
    public int enemy1sLeft = 50;
    public int enemy2sLeft = 25;
    public int enemy3sLeft = 10;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject spawner;

    public float enemy1SpawnTimer = 0.0f;
    public float enemy2SpawnTimer = 0.0f;
    public float enemy3SpawnTimer = 0.0f;

    public Transform spawnPoint;

    void Update()
    {
        enemy1SpawnTimer += Time.deltaTime;
        enemy2SpawnTimer += Time.deltaTime;
        enemy3SpawnTimer += Time.deltaTime;


        if (enemy1SpawnTimer >= 1 && enemy1sLeft > 0)
        {
            Instantiate(enemy1, spawnPoint);
            enemy1SpawnTimer = 0;
            enemy1sLeft--;
        }

        if (enemy2SpawnTimer >= 1.5 && enemy2sLeft > 0)
        {
            Instantiate(enemy2, spawnPoint);
            enemy2SpawnTimer = 0;
            enemy2sLeft--;
        }

        if (enemy3SpawnTimer >= 2.5 && enemy3sLeft > 0)
        {
            Instantiate(enemy3, spawnPoint);
            enemy3SpawnTimer = 0;
            enemy3sLeft--;
        }


    }

}
