using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour {

    public int playerHealth = 20;

    void OnTriggerEnter2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            playerHealth--;
        }
    }
}
