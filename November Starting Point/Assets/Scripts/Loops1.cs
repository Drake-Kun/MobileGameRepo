using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (true) {
			Debug.Log ("Do the thing!");
		}
		int dishes = 5;
		while (dishes > 0) {
			Debug.Log ("I cleaned a dish!");
			dishes--;
		}


		int pans = 4;
		while (true) {
			Debug.Log ("I need to wash " + pans + " pans");
			pans--;
			if (pans == 0) {
				break;
			}
		}



		int num = 0;
		for (int i = 0; i <= 100; i++) {
			num += i;
			Debug.Log (num);
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
