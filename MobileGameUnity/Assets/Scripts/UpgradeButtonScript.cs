using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour {

	public GameObject towerSelected;

	public int costToUpgrade;

	public GameObject upgradeCostText;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    void Update () {

        towerSelected = GameObject.Find("BaseTowerCanvas").GetComponent<BaseTowerCanvasScript>().towerSelected;

        if (towerSelected.GetComponent<TowerDamage> ().towerType != "null") 
		{
			GetComponent<Canvas> ().enabled = true;
		}

        else
        {
            GetComponent<Canvas>().enabled = false;
        }

		if(towerSelected.GetComponent<TowerDamage>().upgrade1 == false)
		{
			costToUpgrade = towerSelected.GetComponent<TowerDamage> ().costToUpgrade;
		}

		if (towerSelected.GetComponent<TowerDamage> ().upgrade2 == false && towerSelected.GetComponent<TowerDamage> ().upgrade1 == true) 
		{
			costToUpgrade = towerSelected.GetComponent<TowerDamage> ().costToUpgrade2;
		}

		if(towerSelected.GetComponent<TowerDamage> ().upgrade3 == false && towerSelected.GetComponent<TowerDamage> ().upgrade2 == true)
		{
			costToUpgrade = towerSelected.GetComponent<TowerDamage> ().costToUpgrade3;
		}

		if (towerSelected.GetComponent<TowerDamage> ().upgrade3 == true) 
		{
			costToUpgrade = 0;
		}

		if (costToUpgrade > 0) 
		{
			upgradeCostText.GetComponent<Text> ().text = costToUpgrade + "g";
		}

		if (costToUpgrade == 0) 
		{
			upgradeCostText.GetComponent<Text>().text = "-x-";
		}
	}
}
