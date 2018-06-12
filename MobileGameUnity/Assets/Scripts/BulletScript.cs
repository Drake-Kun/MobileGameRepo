using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject target;
    public Transform targetPoint;
    public int damage;

    public bool slowAreaActive;

    private Vector2 moveDirection;
    private float distanceToTarget;
    public int moveSpeed = 2;

    public bool iAmYogurt = false;
    public float slowExponent;

    public GameObject slowArea;
    public Transform slowAreaSpawnPoint;


    void Start()
    {
        if (GetComponentInParent<TowerDamage>().towerType == "weeabooTower")
        {
            iAmYogurt = true;
            slowExponent = GetComponentInParent<TowerDamage>().movementSlow;
        }
        target = GetComponentInParent<TowerDamage>().target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }

        slowAreaSpawnPoint = gameObject.transform;

        Vector3 targetPosition = target.transform.position;
        moveDirection = new Vector2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y);
        distanceToTarget = moveDirection.magnitude;
        moveDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

        targetPoint = target.transform;
        transform.right = targetPoint.position - transform.position;


        if (distanceToTarget < 0.1)
        {
            damage = GetComponentInParent<TowerDamage>().attackDamage;
            target.GetComponent<EnemyScriptV2>().healthPoints -= damage;
            if (iAmYogurt == true)
            {
                GetComponent<CircleCollider2D>().radius = 1;
                slowAreaActive = true;
            }
            

            Destroy(gameObject);
        }
    }



}
