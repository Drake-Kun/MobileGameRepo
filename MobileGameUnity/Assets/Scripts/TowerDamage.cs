using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour {

    //We will have several types of towers, what is the best way to differentiate them? Several bools? An int or a string?
    public string towerType = "luciferTower";
    public bool upgrade1 = false;
    public bool upgrade2 = false;
    public bool upgrade3 = false;

    public GameObject playerInfoHub;

    public int goldPerSecond = 0;

    public float luciferTimer = 0.0f;
    public bool victory = false;

    public GameObject target;
    public int money = 0;
    public int costToUpgrade = 0;
    public int costToUpgrade2 = 0;
    public int costToUpgrade3 = 0;

    public float attackRange = 0.0f;
    public int attackDamage = 0;
    public float attackCooldown = 0.0f;

    public float needleCooldown = 0.0f;

    private Vector2 enemyDirection;



    // Update is called once per frame
    void Update()
    {
        TowerTypeCheck();

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
        if (enemyDistance < attackRange)
        {

            float timer = 0.0f;
            timer += Time.deltaTime;



            timer = 0.0f;

            if (luciferTimer >= 30.0f)
            {
                victory = true;
            }
        }
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
            attackRange = 20.0f;
            attackDamage = 30;
            attackCooldown = 5.0f;

            if (upgrade1 == true)
            {
                attackRange = 25.0f;
                attackDamage = 45;
                attackCooldown = 4.5f;

                if (upgrade2 == true)
                {
                    attackRange = 30.0f;
                    attackDamage = 60;
                    attackCooldown = 3.5f;

                    if (upgrade3 == true)
                    {
                        attackRange = 40.0f;
                        attackDamage = 100;
                        attackCooldown = 2.5f;
                    }
                }
            }
        }

        if (towerType == "bulletTower")
        {
            attackRange = 10.0f;
            attackDamage = 10;
            attackCooldown = 1.0f;

            if (upgrade1 == true)
            {
                attackRange = 12.5f;
                attackDamage = 15;
                attackCooldown = 0.9f;

                if (upgrade2 == true)
                {
                    attackRange = 15.0f;
                    attackDamage = 20;
                    attackCooldown = 0.75f;

                    if (upgrade3 == true)
                    {
                        attackRange = 20.0f;
                        attackDamage = 30;
                        attackCooldown = 0.5f;
                    }
                }
            }
        }

        if (towerType == "weeabooTower")
        {
            attackRange = 7.5f;
            attackDamage = 5;
            attackCooldown = 2.0f
            //-10% to enemy movement speed

            if (upgrade1 == true)
            {
                attackRange = 10.0f;
                attackDamage = 10;
                attackCooldown = 1.75f;
                //-20%to enemy movement speed

                if (upgrade2 == true)
                {
                    attackRange = 12.5f;
                    attackDamage = 15;
                    attackCooldown = 1.5f;
                    //-30% to enemy movement speed

                    if (upgrade3 == true)
                    {
                        attackRange = 15.0f;
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

            if (upgrade1 == true)
            {
                needleCooldown = 2.5f;

                if (upgrade2 == true)
                {
                    needleCooldown = 2.0f;

                    if (upgrade3 == true)
                    {
                        needleCooldown = 1.0f;
                    }
                }
            }
        } 
    }
}
