using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetPlatformerMovement : MonoBehaviour {

	// Use this for initialization
	public float jumpSpeed = 3.0f;
	public float moveSpeed = 3.0f;
	private bool grounded = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
		velocity.x = moveX * moveSpeed;
		GetComponent<Rigidbody2D>().velocity = velocity;
		if(Input.GetButtonDown("Jump") && grounded)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
			grounded = false;
		}
	}

	public void Grounded()
		{
			grounded = true;
		}


	public void NotGrounded()
		{
			grounded = false;
		}
}
