using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashyBird : MonoBehaviour {
	
	public float moveSpeed = 5.0f;
	public float flapSpeed = 10.0f;

	void Start () {
		
	}

	void Update () {
		Vector2 move = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		GetComponent<Rigidbody2D> ().velocity = move;

		if (Input.anyKeyDown) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, flapSpeed));
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
