using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject checkpoint;

    public int checkpointNumber = 0;

    private Vector2 moveDirection;
    private float distanceToCheckpoint;
    public int moveSpeed = 2;

    private void OnTriggerEnter2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    void Update () {

        if (distanceToCheckpoint <= 0.1f)
        {
            checkpoint = GameObject.Find("Placeholder (" + checkpointNumber + ")");
            checkpointNumber++;
        }

        Vector3 checkpointPosition = checkpoint.transform.position;
        moveDirection = new Vector2(checkpointPosition.x - transform.position.x, checkpointPosition.y - transform.position.y);
        distanceToCheckpoint = moveDirection.magnitude;
        moveDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

    }
}
