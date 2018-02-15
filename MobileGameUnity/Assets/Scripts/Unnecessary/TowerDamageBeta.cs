using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamageBeta : MonoBehaviour {

    public GameObject target;

    public float timer = 0.0f;

    public List<GameObject> enemiesInRange = new List<GameObject>();

   
    void OnTriggerEnter2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(myCollisionInfo.gameObject);
        } 
    }

    void OnTriggerExit2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(myCollisionInfo.gameObject);
        }
    }

    void Update () {

        timer += Time.deltaTime;

        target = enemiesInRange[0];

        if (timer >= 1 && enemiesInRange.Count > 0)
        {
            target.GetComponent<EnemyMovement>().healthPoints -= 10;
            timer = 0;
        }

	}
}
