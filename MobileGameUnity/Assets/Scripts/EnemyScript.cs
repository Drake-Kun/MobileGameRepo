using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int healthPoints = 10;

    public GameObject checkpoint1;
    private bool checkpoint1Reached = false;

    public GameObject checkpoint2;
    private bool checkpoint2Reached = false;

    public GameObject checkpoint3;
    private bool checkpoint3Reached = false;

    public GameObject finish;

    private float targetPriority = 0.0f;
    private Vector2 moveDirection;
    private float distanceToCheckpoint;
    public int moveSpeed = 2; 

    void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.name == "finish")
        {
            //playerHealth -= 1;
            Destroy(gameObject);
        }

        if (myCollisionInfo.gameObject.name == "groundNeedles")
        {
            healthPoints -= needleDamage * needleLevel;
        }
    }

    void Start ()
    {
        distanceToCheckpoint = 5.0f;
    }

    void Update ()
    {

        targetPriority += Time.deltaTime;

        if (checkpoint1Reached == false)
        {
            Vector3 checkpointPosition = checkpoint1.transform.position;
            moveDirection = new Vector2(checkpointPosition.x - transform.position.x, checkpointPosition.y - transform.position.y);
            distanceToCheckpoint = moveDirection.magnitude;
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

            if (distanceToCheckpoint < 0.1f)
            {
                checkpoint1Reached = true;
            }
        }

        if (checkpoint2Reached == false && checkpoint1Reached == true)
        {
            Vector3 checkpointPosition = checkpoint2.transform.position;
            moveDirection = new Vector2(checkpointPosition.x - transform.position.x, checkpointPosition.y - transform.position.y);
            distanceToCheckpoint = moveDirection.magnitude;
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

            if (distanceToCheckpoint < 0.1f)
            {
                checkpoint2Reached = true;
            }
        }

        if (checkpoint3Reached == false && checkpoint2Reached == true)
        {
            Vector3 checkpointPosition = checkpoint3.transform.position;
            moveDirection = new Vector2(checkpointPosition.x - transform.position.x, checkpointPosition.y - transform.position.y);
            distanceToCheckpoint = moveDirection.magnitude;
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

            if (distanceToCheckpoint < 0.1f)
            {
                checkpoint3Reached = true;
            }
        }

        if (checkpoint3Reached == true)
        {
            Vector3 checkpointPosition = finish.transform.position;
            moveDirection = new Vector2(checkpointPosition.x - transform.position.x, checkpointPosition.y - transform.position.y);
            distanceToCheckpoint = moveDirection.magnitude;
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;
        }

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
