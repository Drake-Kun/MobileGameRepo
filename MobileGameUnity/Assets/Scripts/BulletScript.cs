﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject target;

    private Vector2 moveDirection;
    private float distanceToTarget;
    public int moveSpeed = 2;


    void Start()
    {
        target = GetComponentInParent<TowerDamage>().target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }

        Vector3 targetPosition = target.transform.position;
        moveDirection = new Vector2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y);
        distanceToTarget = moveDirection.magnitude;
        moveDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

        if (distanceToTarget < 0.1)
        {
            Destroy(gameObject);
        }
    }

}