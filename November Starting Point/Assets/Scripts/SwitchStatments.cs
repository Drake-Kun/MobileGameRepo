using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStatments : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int money = 10;

		switch (money) 
		{
		case 10:
			Debug.Log ("You're the richest person in town!");
			break;
		case 9:
			Debug.Log ("You're like, pretty rich man.");
			break;
		case 8:
			Debug.Log ("You're doing pretty well for yourself/");
			break;
		case 7:
			Debug.Log ("You can reasonably support yourself.");
			break;
		default:
			Debug.Log("You have " + money + " moneys");
			break;
		}

		int renown = 10;

		switch (renown) 
		{

		default:
			Debug.Log ("Who are you?");
			break;

		case 1:
			Debug.Log ("The people here hate you.");
			break;

		case 2:
			Debug.Log ("We don't want you here.");
			break;
		
		case 3:
			Debug.Log ("Some of us are uncomfortable with you here.");
			break;

		case 4:
			Debug.Log ("There are some bad rumors spreading about you.");
			break;

		case 5:
			Debug.Log ("You're okay I suppose.");
			break;

		case 6:
			Debug.Log ("I think the people here like you a little.");
			break;
		
		case 7:
			Debug.Log ("You're pretty cool.");
			break;

		case 8:
			Debug.Log ("Maybe you should stick around town some.");
			break;

		case 9:
			Debug.Log ("We're glad to have you in town.");
			break;
		
		case 10:
			Debug.Log ("If we had a king, we'd overthrow him and make you the new king!");
			break;

		}

	}

}
