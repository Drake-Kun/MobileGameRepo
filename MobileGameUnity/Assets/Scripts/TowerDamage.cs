using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour {

    public GameObject target;
    public float attackRange = 10.0f;
    private Vector2 enemyDirection;



    // Update is called once per frame
    void Update()
    {
        float enemyDistance = 0.0f;
        Vector3 enemyPosition = target.transform.position;
        enemyDirection = new Vector2(enemyPosition.x - transform.position.x, enemyPosition.y - transform.position.y);
        enemyDistance = enemyDirection.magnitude;
        //if there is an enemy in range, attack the one that has the highest target priority
        if (enemyDistance < attackRange)
        {

            float timer = 0.0f;
            timer += Time.deltaTime;

                if (timer > 5)
                {
                    //do damage to the enemy
                }

            timer = 0.0f;
        }
    }
}
