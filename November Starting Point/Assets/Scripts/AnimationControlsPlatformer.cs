using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlsPlatformer : MonoBehaviour {

	// Use this for initialization
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		float input_X = Input.GetAxisRaw ("Horizontal");
		bool isWalking = (Mathf.Abs (input_X) > 0);

		anim.SetBool ("isWalking", isWalking);
		if (isWalking) 
		{
			anim.SetFloat ("X", input_X);
		}
	}
}
