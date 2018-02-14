using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamageBeta : MonoBehaviour {

    public GameObject target;

    public float timer = 0.0f;

    List<GameObject> enemiesInRange = new List<GameObject>();

   
    void OnTriggerEnter2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(gameObject);
        } 
    }

    void OnTriggerExit2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(gameObject);
        }
    }

    void Update () {

        timer += Time.deltaTime;

        target = enemiesInRange[0];

        if (timer >= 5)
        {
            target.GetComponent<EnemyMovement>().health -= 10;
        }

	}
}
