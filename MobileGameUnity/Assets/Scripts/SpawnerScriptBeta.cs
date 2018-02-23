using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScriptBeta : MonoBehaviour {

    
    public int enemy1sLeft;
    public int enemy2sLeft;
    public int enemy3sLeft;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject spawner;

    public float enemy1SpawnTimer;
    public float timer1;
    public float enemy2SpawnTimer;
    public float timer2;
    public float enemy3SpawnTimer;
    public float timer3;

    public Transform spawnPoint;

    void Start()
    {
        timer1 = enemy1SpawnTimer;
        timer2 = enemy2SpawnTimer;
        timer3 = enemy3SpawnTimer;
    }

    void Update()
    {
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        timer3 -= Time.deltaTime;


        if (timer1 <= 0 && enemy1sLeft > 0)
        {
            Instantiate(enemy1, spawnPoint);
            timer1 = enemy1SpawnTimer;
            enemy1sLeft--;
        }

        if (timer2 <= 0 && enemy2sLeft > 0)
        {
            Instantiate(enemy2, spawnPoint);
            timer2 = enemy2SpawnTimer;
            enemy2sLeft--;
        }

        if (timer3 <= 0 && enemy3sLeft > 0)
        {
            Instantiate(enemy3, spawnPoint);
            timer3 = enemy3SpawnTimer;
            enemy3sLeft--;
        }


    }

}
