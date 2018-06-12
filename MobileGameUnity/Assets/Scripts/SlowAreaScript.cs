using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAreaScript : MonoBehaviour {

    public float deathTimer = 2.0f;
    public float slowExponent;

	// Use this for initialization
	void Start () {
        slowExponent = GetComponentInParent<BulletScript>().slowExponent;
	}
	
	// Update is called once per frame
	void Update () {
        if (deathTimer <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            myCollisionInfo.gameObject.GetComponent<EnemyScriptV2>().moveSpeed *= slowExponent;
        }
    }
}
