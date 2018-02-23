using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptV2 : MonoBehaviour {

    public int healthPointsMax = 50;
    public int healthPoints;
    public int healthPercent;
    public GameObject healthBar;
    public Sprite hundredPercent;
    public Sprite ninetyPercent;
    public Sprite eightyPercent;
    public Sprite seventyPercent;
    public Sprite sixtyPercent;
    public Sprite fiftyPercent;
    public Sprite fourtyPercent;
    public Sprite thirtyPercent;
    public Sprite twentyPercent;
    public Sprite tenPercent;

    public GameObject checkpoint;

    public int checkpointNumber = 0;

    private Vector2 moveDirection;
    private float distanceToCheckpoint;
    public float baseMovementSpeed = 2.0f;
    public float moveSpeed = 2.0f;

    public bool slowed = false;
    public float slowExponent;
    public float slowTimer;

    void Start()
    {
        healthPoints = healthPointsMax;
    }

    void OnTriggerEnter2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.name == "slowArea (copy)")
        {
            slowed = true;
            if (slowExponent < myCollisionInfo.gameObject.GetComponent<SlowAreaScript>().slowExponent)
            {
                slowExponent = myCollisionInfo.gameObject.GetComponent<SlowAreaScript>().slowExponent;
            }
            slowTimer = 2.5f;
        }

        if (myCollisionInfo.gameObject.tag == "Finish")
        {
            GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerHealth--;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        HealthCheck();

        if (slowed == true)
        {
            moveSpeed = baseMovementSpeed / slowExponent;
        }

        slowTimer -= Time.deltaTime;

        if (slowTimer <= 0)
        {
            slowed = false;
            slowExponent = 0;
        }

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

    void HealthCheck()
    {
        healthPercent = healthPoints * 100 / healthPointsMax;


        if (healthPercent == 100)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = hundredPercent;
        }

        if (healthPercent >= 90 && healthPercent <= 99)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = ninetyPercent;
        }

        if (healthPercent >= 80 && healthPercent <= 89)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = eightyPercent;
        }

        if (healthPercent >= 70 && healthPercent <= 79)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = seventyPercent;
        }

        if (healthPercent >= 60 && healthPercent <= 69)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = sixtyPercent;
        }

        if (healthPercent >= 50 && healthPercent <= 59)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = fiftyPercent;
        }

        if (healthPercent >= 40 && healthPercent <= 49)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = fourtyPercent;
        }

        if (healthPercent >= 30 && healthPercent <= 39)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = thirtyPercent;
        }

        if (healthPercent >= 20 && healthPercent <= 29)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = twentyPercent;
        }

        if (healthPercent >= 0 && healthPercent <= 19)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = tenPercent;
        }

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
