using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonScript : MonoBehaviour {

	public GameObject towerSelected;
	

	void Update () {
		towerSelected = GameObject.Find ("Main Canvas").GetComponent<BaseTowerCanvasScript>().towerSelected;
		if (towerSelected.GetComponent<TowerDamage> ().towerType != "null") 
		{
			
		}
	}
}
