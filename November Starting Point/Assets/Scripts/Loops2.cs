using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//unity is broken. cmd denies me. I cry.


		//my answers

		int loopNumber = 1;
		while (loopNumber <= 10) {
			Debug.Log ("I am on loop iteration number " + loopNumber + "!");
			loopNumber++;
		}
		if (true)
			Debug.Log ("blah");
		





		int num = 0;
		for (int i = 176; i <= 1000; i++) {
			num += i;
		}






		for (int r = 0; r <= 99; r++) {
			int roll1 = Random.Range (1, 7);
			int roll2 = Random.Range (1, 7);
			int rollFinal = roll1 + roll2;
			if (rollFinal == 12) {
				break;
			}
		}




		//Adle's answers

		//problem 1
		for (int i = 1; i <= 10; i++) {
			Debug.Log("We're on loop " + i); 
		}

		//problem 1
		int count = 1;
		while (count <= 10) {
			Debug.Log ("We're on loop " + count);
			count++;
		}


		//problem 2
		int sum = 0;
		for (int i = 176; i <= 1000; i++) {
			sum += i;
		}

		//problem 3
		for(int i = 1; i <= 100; i++){
			int roll1 = Random.Range (1, 7);
			int roll2 = Random.Range (1, 7);
			if (roll1 + roll2 == 12) {
				break;
			}
		}




	}
}
