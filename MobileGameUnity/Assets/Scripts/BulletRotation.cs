using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
        target = GetComponentInParent<TowerDamage>().target.transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPostition = new Vector3(target.position.x, transform.position.y, this.target.position.z);
        this.transform.LookAt(targetPostition);
    }
}
