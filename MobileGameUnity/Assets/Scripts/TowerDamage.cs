using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour {
   

    //We will have several types of towers, what is the best way to differentiate them? Several bools? An int or a string?
    public string towerType = "null";
    public bool upgrade1 = false;
    public bool upgrade2 = false;
    public bool upgrade3 = false;

    public GameObject playerInfoHub;

    public int goldPerSecond = 0;
	public float goldTimer = 1;

    public float luciferTimer = 0.0f;
    public float towerTimer = 0.0f;
    public bool victory = false;

    public GameObject target;

    public int costCashTower = 100;
    public int costBulletTower = 150;
    public int costArtilleryTower = 200;
    public int costWeeabooTower = 200;

    public int costToUpgrade = 0;
    public int costToUpgrade2 = 0;
    public int costToUpgrade3 = 0;


    public float attackRange = 0.0f;
    public int attackDamage = 0;
    public float attackCooldown = 0.0f;
    public float movementSlow = 0.0f;

    public Transform bulletSpawnPoint;
    public GameObject bullet;

	public GameObject bulletTypeA;
	public GameObject bulletTypeB1;
	public GameObject bulletTypeB2;
	public GameObject bulletTypeB3;
	public GameObject bulletTypeC;


    public float needleCooldown = 0.0f;
    public int needleDamage = 0;

    private Vector2 enemyDirection;

    public List<GameObject> enemiesInRange = new List<GameObject>();

	public Sprite cashTower1;
	public Sprite cashTower2;
	public Sprite cashTower3;
	public Sprite cashTower4;

	public Sprite bulletTower1;
	public Sprite bulletTower2;
	public Sprite bulletTower3;
	public Sprite bulletTower4;

	public Sprite artilleryTower1;
	public Sprite artilleryTower2;
	public Sprite artilleryTower3;
	public Sprite artilleryTower4;

	public Sprite weeabooTower1;
	public Sprite weeabooTower2;
	public Sprite weeabooTower3;
	public Sprite weeabooTower4;


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
		goldTimer -= Time.deltaTime;
		if (goldTimer <= 0) 
		{
			GameObject.Find ("Main Camera").GetComponent<PlayerInfoScript> ().playerGold += goldPerSecond;
			goldTimer += 1;
		}
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

    public void BuyLuciferTower()
    {
        towerType = "luciferTower";
    }

    public void BuyBulletTower()
    {
		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costBulletTower)
        {
            GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costBulletTower;
            towerType = "bulletTower";
            costToUpgrade = 100;
            costToUpgrade2 = 150;
            costToUpgrade3 = 200;
        }
    }

    public void BuyArtilleryTower()
    {
		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costArtilleryTower)
        {
            GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costArtilleryTower;
            towerType = "artilleryTower";
            costToUpgrade = 150;
            costToUpgrade2 = 225;
            costToUpgrade3 = 300;
        }
    }

    public void BuyWeeabooTower()
    {
		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costWeeabooTower)
        {
            GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costWeeabooTower;
            towerType = "weeabooTower";
            costToUpgrade = 150;
            costToUpgrade2 = 200;
            costToUpgrade3 = 250;
        }
    }

    public void BuyCashTower()
    {
		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costCashTower)
        {
            GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costCashTower;
            towerType = "cashTower";
            costToUpgrade = 100;
            costToUpgrade2 = 175;
            costToUpgrade3 = 250;
        }
    }

    public void UpgradeButton()
    {
        if (towerType == "null")
        {
            return;
        }
		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costToUpgrade && upgrade1 == false)
        {
			GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costToUpgrade;
            upgrade1 = true;
            return;
        }

		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costToUpgrade2 && upgrade2 == false && upgrade1 == true)
        {
			GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costToUpgrade2;
            upgrade2 = true;
            return;
        }

		if (GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold >= costToUpgrade3 && upgrade3 == false && upgrade1 == true && upgrade2 == true)
        {
			GameObject.Find("Main Camera").GetComponent<PlayerInfoScript>().playerGold -= costToUpgrade3;
            upgrade3 = true;
            return;
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
			GetComponent<SpriteRenderer>().sprite = artilleryTower1;
			bullet = bulletTypeB1;
            attackRange = 3.0f;
            attackDamage = 30;
            attackCooldown = 5.0f;

            if (upgrade1 == true)
            {
				GetComponent<SpriteRenderer>().sprite = artilleryTower2;
                attackRange = 3.5f;
                attackDamage = 45;
                attackCooldown = 4.5f;

                if (upgrade2 == true)
                {
					GetComponent<SpriteRenderer>().sprite = artilleryTower3;
					bullet = bulletTypeB2;
                    attackRange = 4.0f;
                    attackDamage = 60;
                    attackCooldown = 3.5f;

                    if (upgrade3 == true)
                    {
						GetComponent<SpriteRenderer>().sprite = artilleryTower4;
						bullet = bulletTypeB3;
                        attackRange = 5.0f;
                        attackDamage = 100;
                        attackCooldown = 2.5f;
                    }
                }
            }
        }

        if (towerType == "bulletTower")
        {
			GetComponent<SpriteRenderer>().sprite = bulletTower1;
			bullet = bulletTypeA;
            attackRange = 2.0f;
            attackDamage = 10;
            attackCooldown = 1.0f;

            if (upgrade1 == true)
            {
				GetComponent<SpriteRenderer>().sprite = bulletTower2;
                attackRange = 2.25f;
                attackDamage = 15;
                attackCooldown = 0.9f;

                if (upgrade2 == true)
                {
					GetComponent<SpriteRenderer>().sprite = bulletTower3;
                    attackRange = 2.5f;
                    attackDamage = 20;
                    attackCooldown = 0.75f;

                    if (upgrade3 == true)
                    {
						GetComponent<SpriteRenderer>().sprite = bulletTower4;
                        attackRange = 3.0f;
                        attackDamage = 30;
                        attackCooldown = 0.5f;
                    }
                }
            }
        }

        if (towerType == "weeabooTower")
        {
			GetComponent<SpriteRenderer>().sprite = weeabooTower1;
			bullet = bulletTypeC;
            attackRange = 2.0f;
            attackDamage = 5;
            attackCooldown = 2.0f;
            movementSlow = 1.1f;

            if (upgrade1 == true)
            {
				GetComponent<SpriteRenderer>().sprite = weeabooTower2;
                attackRange = 2.25f;
                attackDamage = 10;
                attackCooldown = 1.75f;
                movementSlow = 1.25f;

                if (upgrade2 == true)
                {
					GetComponent<SpriteRenderer>().sprite = weeabooTower3;
                    attackRange = 2.5f;
                    attackDamage = 15;
                    attackCooldown = 1.5f;
                    movementSlow = 1.5f;

                    if (upgrade3 == true)
                    {
						GetComponent<SpriteRenderer>().sprite = weeabooTower4;
                        attackRange = 3.0f;
                        attackDamage = 20;
                        attackCooldown = 1.0f;
                        movementSlow = 2.0f;
                    }
                }
            }
        }

        if (towerType == "cashTower")
        {
			GetComponent<SpriteRenderer>().sprite = cashTower1;
            goldPerSecond = 5;

            if (upgrade1 == true)
            {
				GetComponent<SpriteRenderer>().sprite = cashTower2;
                goldPerSecond = 10;

                if (upgrade2 == true)
                {
					GetComponent<SpriteRenderer>().sprite = cashTower3;
                    goldPerSecond = 15;

                    if (upgrade3 == true)
                    {
						GetComponent<SpriteRenderer>().sprite = cashTower4;
                        goldPerSecond = 20;
                    }
                }
            }
        }
    }
}
