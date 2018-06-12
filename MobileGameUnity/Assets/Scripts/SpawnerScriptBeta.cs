using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnerScriptBeta : MonoBehaviour {

    public bool level1;
    public bool level2;
    public bool level3;

    public bool easy;
    public bool normal;
    public bool hard;

    public int enemy1sLeft;
    public int enemy2sLeft;
    public int enemy3sLeft;

    public int enemy1sMax;
    public int enemy2sMax;
    public int enemy3sMax;

    public int enemy1sAlive;
    public int enemy2sAlive;
    public int enemy3sAlive;

    public int enemiesLeftTotal;
    public int enemiesAliveTotal;

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

    public GameObject adelBotText;
    public GameObject adelDroidText;
    public GameObject adelNutText;

    void Start()
	{
        timer1 = enemy1SpawnTimer;
        timer2 = enemy2SpawnTimer;
        timer3 = enemy3SpawnTimer;

        enemy1sMax = enemy1sLeft;
        enemy2sMax = enemy2sLeft;
        enemy3sMax = enemy3sLeft;
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
            enemiesAliveTotal++;
        }

        if (timer2 <= 0 && enemy2sLeft > 0)
        {
            Instantiate(enemy2, spawnPoint);
            timer2 = enemy2SpawnTimer;
            enemy2sLeft--;
            enemiesAliveTotal++;
        }

        if (timer3 <= 0 && enemy3sLeft > 0)
        {
            Instantiate(enemy3, spawnPoint);
            timer3 = enemy3SpawnTimer;
            enemy3sLeft--;
            enemiesAliveTotal++;
        }

        enemiesLeftTotal = enemy1sLeft + enemy2sLeft + enemy3sLeft;

        adelBotText.GetComponent<Text>().text = "AdelBots Alive: " + enemy1sLeft + " / " + enemy1sMax;
        adelDroidText.GetComponent<Text>().text = "AdelDroids Alive: " + enemy2sLeft + " / " + enemy2sMax;
        adelNutText.GetComponent<Text>().text = "AdelNuts Alive: " + enemy3sLeft + " / " + enemy3sMax;

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level1 == true && normal == true)
        {
            SceneManager.LoadScene("Level2Normal");
        }

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level2 == true && normal == true)
        {
            SceneManager.LoadScene("Level3Normal");
        }

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level1 == true && easy == true)
        {
            SceneManager.LoadScene("Level2Easy");
        }

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level2 == true && easy == true)
        {
            SceneManager.LoadScene("Level3Easy");
        }

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level1 == true && hard == true)
        {
            SceneManager.LoadScene("Level2Hard");
        }

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level2 == true && hard == true)
        {
            SceneManager.LoadScene("Level3Hard");
        }

        if (enemiesLeftTotal == 0 && enemiesAliveTotal == 0 && GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth >= 0 && level3 == true)
        {
            SceneManager.LoadScene("Victory");
        }
    }

}
