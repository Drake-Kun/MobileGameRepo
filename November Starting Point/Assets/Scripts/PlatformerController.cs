using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour {

	public float moveSpeed = 3.0f;
	public float jumpSpeed = 3.0f;
	private bool grounded = false;
	private bool doubleJump = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		//gets the horizontal input for moving the player side to side
		float moveX = Input.GetAxis ("Horizontal");
		//gets a copy of the velocity to maintain the gravity (if any)
		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		//changes the velocity x to be impacted by user input
		velocity.x = moveX * moveSpeed;
		//sends the velocity back to the rigidbody
		GetComponent<Rigidbody2D> ().velocity = velocity;

		//if you press the jump key and you're grounded, you can jump
		if (Input.GetButtonDown ("Jump") && grounded) {
			//we are assuming that there is an animator on the player, 
			//and that animator has a boolean called "isJumping" parameter
			GetComponent<Animator> ().SetBool ("isJumping", true);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 100 * jumpSpeed));
		}

		if (Input.GetButtonDown ("Jump") && doubleJump) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 100 * jumpSpeed));
			doubleJump = false;
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		//we are assuming that there is an animator on the player, 
		//and that animator has a boolean called "isJumping" parameter
		GetComponent<Animator> ().SetBool ("isJumping", false);
		if (collision.gameObject.layer == 8) {
			grounded = true;
			doubleJump = false;
		}
	}

	void OnCollisionExit2D (Collision2D collision){
		if (collision.gameObject.layer == 8) {
			grounded = false;
			doubleJump = true;
		}
	}

	void OnCollisionStay2D (Collision2D collision){
		if (collision.gameObject.layer == 8) {
			grounded = true;
		}
	}
}
