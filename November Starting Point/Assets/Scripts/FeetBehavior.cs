using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetBehavior : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision)
	{
		//if our feet run into an object on layer 8
		if (collision.gameObject.layer == 8) 
		{
			//tell the player they can jump
			transform.parent.GetComponent<FeetPlatformerMovement>().Grounded();
		}	
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		//if our feet run into an object on layer 8
		if (collision.gameObject.layer == 8) 
		{
			//tell the player they can jump
			transform.parent.GetComponent<FeetPlatformerMovement>().NotGrounded();
		}	
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		//if our feet run into an object on layer 8
		if (collision.gameObject.layer == 8) 
		{
			//tell the player they can jump
			transform.parent.GetComponent<FeetPlatformerMovement>().Grounded();
		}	
	}
}
