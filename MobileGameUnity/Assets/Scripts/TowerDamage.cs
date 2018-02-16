using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour {

    //We will have several types of towers, what is the best way to differentiate them? Several bools? An int or a string?
    public string towerType = "bulletTower";
    public bool upgrade1 = true;
    public bool upgrade2 = true;
    public bool upgrade3 = false;

    public GameObject playerInfoHub;

    public int goldPerSecond = 0;

    public float luciferTimer = 0.0f;
    public float towerTimer = 0.0f;
    public bool victory = false;

    public GameObject target;
    public int money = 0;
    public int costToUpgrade = 0;
    public int costToUpgrade2 = 0;
    public int costToUpgrade3 = 0;

    public float attackRange = 0.0f;
    public int attackDamage = 0;
    public float attackCooldown = 0.0f;

    public Transform bulletSpawnPoint;
    public GameObject bullet;

    public float needleCooldown = 0.0f;
    public int needleDamage = 0;

    private Vector2 enemyDirection;

    public List<GameObject> enemiesInRange = new List<GameObject>();


    void OnTriggerEnter2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(myCollisionInfo.gameObject);
            Debug.Log("ENEMY IN RANGE");
        }
    }

    void OnTriggerExit2D(Collider2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(myCollisionInfo.gameObject);
            Debug.Log("RECALCULATING");
        }
    }

    void Update()
    {
        TowerTypeCheck();
        GetComponent<CircleCollider2D>().radius = attackRange;

        towerTimer += Time.deltaTime;

        target = enemiesInRange[0];

        if (towerTimer >= attackCooldown && enemiesInRange.Count > 0)
        {
            towerTimer = 0;

            Instantiate(bullet, bulletSpawnPoint);
        }

        if (luciferTimer >= 30.0f)
        {
            victory = true;
        }

        if (towerType == "needleTower")
        {
            //find the closest node, place needles on that node until it's at needleLevel4,
            //find the next closest node that is closest to the enemy spawn, place needles on the node until it's at needleLevel4,
            //then find the next closest node that is closest to the enemy finish, place needles on the node until it's at needleLevel4. 
        }

        float enemyDistance = 0.0f;
        Vector3 enemyPosition = target.transform.position;
        enemyDirection = new Vector2(enemyPosition.x - transform.position.x, enemyPosition.y - transform.position.y);
        enemyDistance = enemyDirection.magnitude;
        //if there is an enemy in range, attack the one that has the highest target priority

        
        
    }

    public void BuyTower()
    {

    }

    public void BuyLuciferTower()
    {
        towerType = "luciferTower";
    }

    public void BuyBulletTower()
    {
        towerType = "bulletTower";
        costToUpgrade = 100;
        costToUpgrade2 = 150;
        costToUpgrade3 = 200;
    }

    public void BuyArtilleryTower()
    {
        towerType = "artilleryTower";
        costToUpgrade = 150;
        costToUpgrade2 = 225;
        costToUpgrade3 = 300;
    }

    public void BuyWeeabooTower()
    {
        towerType = "weeabooTower";
        costToUpgrade = 150;
        costToUpgrade2 = 200;
        costToUpgrade3 = 250;
    }

    public void BuyCashTower()
    {
        towerType = "cashTower";
        costToUpgrade = 100;
        costToUpgrade2 = 175;
        costToUpgrade3 = 250;
    }

    public void UpgradeButton()
    {
        if (money >= costToUpgrade)
        {
            money -= costToUpgrade;
            upgrade1 = true;
        }
    }

    public void UpgradeButton2()
    {
        if (money >= costToUpgrade2)
        {
           money -= costToUpgrade2;
           upgrade2 = true;
        }
    }
    public void UpgradeButton3()
    { 
        if (upgrade2 == true && money >= costToUpgrade3)
        {
            money -= costToUpgrade3;
            upgrade3 = true;
        }
    }

    public void TowerTypeCheck()
    {
        if (towerType == "luciferTower")
        {
            attackRange = 0.0f;
            attackDamage = 0;
            luciferTimer += Time.deltaTime;

            //If all seals are open (otherwise, if enough time has passed) YOU WIN THE LEVEL
        }

        if (towerType == "artilleryTower")
        {
            attackRange = 3.0f;
            attackDamage = 30;
            attackCooldown = 5.0f;

            if (upgrade1 == true)
            {
                attackRange = 3.5f;
                attackDamage = 45;
                attackCooldown = 4.5f;

                if (upgrade2 == true)
                {
                    attackRange = 4.0f;
                    attackDamage = 60;
                    attackCooldown = 3.5f;

                    if (upgrade3 == true)
                    {
                        attackRange = 5.0f;
                        attackDamage = 100;
                        attackCooldown = 2.5f;
                    }
                }
            }
        }

        if (towerType == "bulletTower")
        {
            attackRange = 2.0f;
            attackDamage = 10;
            attackCooldown = 1.0f;

            if (upgrade1 == true)
            {
                attackRange = 2.25f;
                attackDamage = 15;
                attackCooldown = 0.9f;

                if (upgrade2 == true)
                {
                    attackRange = 2.5f;
                    attackDamage = 20;
                    attackCooldown = 0.75f;

                    if (upgrade3 == true)
                    {
                        attackRange = 3.0f;
                        attackDamage = 30;
                        attackCooldown = 0.5f;
                    }
                }
            }
        }

        if (towerType == "weeabooTower")
        {
            attackRange = 2.0f;
            attackDamage = 5;
            attackCooldown = 2.0f;
            //-10% to enemy movement speed

            if (upgrade1 == true)
            {
                attackRange = 2.25f;
                attackDamage = 10;
                attackCooldown = 1.75f;
                //-20%to enemy movement speed

                if (upgrade2 == true)
                {
                    attackRange = 2.5f;
                    attackDamage = 15;
                    attackCooldown = 1.5f;
                    //-30% to enemy movement speed

                    if (upgrade3 == true)
                    {
                        attackRange = 3.0f;
                        attackDamage = 20;
                        attackCooldown = 1.0f;
                        //-50% to enemy movement speed
                    }
                }
            }
        }

        if (towerType == "cashTower")
        {
            goldPerSecond = 5;

            if (upgrade1 == true)
            {
                goldPerSecond = 10;

                if (upgrade2 == true)
                {
                    goldPerSecond = 15;

                    if (upgrade3 == true)
                    {
                        goldPerSecond = 20;
                    }
                }
            }
        }

        if (towerType == "needleTower")
        {
            needleCooldown = 3.0f;
            needleDamage = 5;

            if (upgrade1 == true)
            {
                needleCooldown = 2.5f;
                needleDamage = 10;

                if (upgrade2 == true)
                {
                    needleCooldown = 2.0f;
                    needleDamage = 15;

                    if (upgrade3 == true)
                    {
                        needleCooldown = 1.0f;
                        needleDamage = 20;
                    }
                }
            }
        } 
    }
}
