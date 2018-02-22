using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAreaScript : MonoBehaviour {

    public float deathTimer = 0.5f;
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
}
