using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromerAnimationAnimationControls : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float MoveX = Input.GetAxisRaw ("Horizontal");
		//We are assuming that the animaor has a variabel called x,
		//that the variable is capital and that it is a float
		anim.SetFloat ("X", MoveX);
		//We are assuming the animator has a variable called isWalking,
		//the variable is spelled correctly and it is a boolean
		anim.SetBool ("isWalking", MoveX != 0);

	}
}
