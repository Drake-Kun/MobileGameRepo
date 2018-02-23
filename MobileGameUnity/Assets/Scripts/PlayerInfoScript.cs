using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoScript : MonoBehaviour {

    public int playerGold;
    public int playerGoldIncome;
    public float goldTimer;
    public int playerMaxHealth;
    public int playerHealth;

    public GameObject playerCanvas;

    public GameObject playerHealthText;
    public GameObject playerGoldText;


	// Use this for initialization
	void Start () {
        playerCanvas.GetComponent<Canvas>().enabled = true;
        playerGoldIncome = 10;
        playerHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        goldTimer += Time.deltaTime;

        if (goldTimer >= 1)
        {
            playerGold += playerGoldIncome;
            goldTimer = 0;
        }

        playerHealthText.GetComponent<Text>().text = "Life: " + playerHealth + " / " + playerMaxHealth;
        playerGoldText.GetComponent<Text>().text = "Gold: " + playerGold;
    }
}
