using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour {

	public int damage = -5;
	public float speed = 0.125f;
	private bool flip = false;
	public int LaneNum = 2;
	private SpriteRenderer sprite;
	public GameObject player;
	public int playerLane;
	private Vector3 move;
	public float distance = .5f;
	private Vector3 offset;
	public float maxHealth = 100;
	public float health;
	public float maxHealthBarSlide = .2f;
	public GameObject HealthBar;
	private SpriteRenderer healthSprite;
    public bool playerFacing;
    public float distancetostop = 2f;
    public Rigidbody2D currentRB;
    public float enemySpeed = .3f;
    public bool playerOnLevel;
    private Vector3 startingPosition;
    public float chaseRange = 7f;
    private float distanceToPlayer;
	public Vector3 LaneChaseOffset;
	public GameObject marker;
	public GameObject page;

    //projectile properties
    public GameObject projectileRight, projectileLeft;
    public float projectileEnemySpeed = .2f;
    public float shootingRange = 10f;
    public float minimumShootingRange = 5f;
    Vector2 projectilePos;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public bool playerOnLeft;
    public float enemyHeight;
    Animator ani;
    //atticking
    public int AttackRatio =1;
    bool canAttack = false;
    bool PlayerWithinRange;
    int attackCounter = 1;
    GameObject P;

    // Use this for initialization
    void Start () {
        PlayerWithinRange = false;
		health = maxHealth;
		healthSprite = HealthBar.GetComponent<SpriteRenderer>();
		offset = new Vector3(0,distance,0);
		sprite = GetComponent<SpriteRenderer>();
		move = transform.position + offset;
        currentRB = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        ani = GetComponent<Animator>();
        getHit(0);
	}

	// Update is called once per frame
	void Update ()
	{

		GetPlayerLane();
        switch (LaneNum)
        {
            case 1:
                sprite.sortingLayerName = "LowLane";
                //Debug.Log("Change Lane 1");
                break;
            case 2:
                sprite.sortingLayerName = "MidLane";
                //Debug.Log("Change Lane 2");
                break;
            case 3:
                sprite.sortingLayerName = "HighLane";
                //Debug.Log("Change Lane 3");
                break;
        }
        PerformMovement();
        if(PlayerWithinRange)
        {


        }

		if (move == transform.position && flip == false)
		{
			move = transform.position - offset;
			flip = true;
		}
		else if (move == transform.position && flip == true)
		{
			move = transform.position + offset;
			flip = false;
		}
		//transform.position = Vector3.Lerp(transform.position,move,speed*Time.deltaTime);
		//health
		if(health <= 0.0f)
		{
			Instantiate(page, transform.position, transform.rotation);
			Destroy(gameObject);
		}
        if(canAttack)
        {
             attackCounter++;
                if(attackCounter% AttackRatio == 0)
                {
                    //ani.SetBool("Attacking", true);
                    Attack();
                }
                if(attackCounter >= 1000)
                {
                    attackCounter = 1;
                }
        }
	}


	void  OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.name == "LowLane")
		{
			LaneNum = 1;
			//Debug.Log("Lane 1");
		}
		else if (col.gameObject.name == "MidLane")
		{
			LaneNum = 2;
			//Debug.Log("Lane 2");
		}
		else if (col.gameObject.name == "HighLane")
		{
			LaneNum = 3;
			//Debug.Log("Lane 3");
		}

		if (col.gameObject.name == "Player")
		{
            //Debug.Log("Player Trigger");
			int pLane = col.gameObject.GetComponent<playerStatus>().returnLane();
			if (pLane == LaneNum)
			{
               canAttack =true;
				//col.gameObject.GetComponent<playerStatus>().UpdateHealth(damage);
				//col.gameObject.GetComponent<playerMove>().EnemyWithinRange(true, gameObject);
			}
		}



	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "Player")
		{

			col.gameObject.GetComponent<playerMove>().EnemyWithinRange(false, gameObject);
            canAttack = false;
		}
	}

	void GetPlayerLane()
	{
		playerLane = player.GetComponent<playerStatus>().returnLane();

	}
	public void getHit(int damage)
	{
		//Debug.Log(damage);
		health = health - damage;
		Vector3 mi = HealthBar.transform.localScale;
		float v =(float) (maxHealthBarSlide * (health/100));
		mi.x = (float) v;
		HealthBar.transform.localScale = mi;
	}
    public void Attack()
    {
        //Debug.Log("attacking");
        switch (gameObject.tag)
        {
            case "Big Brain":
                player.GetComponent<playerStatus>().UpdateHealth(5);
                break;
           // case "Brain Bear":
           //
           //     break;
            case "Boss":
                player.GetComponent<playerStatus>().UpdateHealth(10);
                break;
        }
        StartCoroutine("wait");

    }
    public void PerformMovement()
    {
        int count = player.gameObject.GetComponent<playerMove>().getFightCount();
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(distanceToPlayer);
        //Debug.Log(count);
        isPlayerOnLevel();
        if (playerOnLevel == true)
        {
            //Big Brain movement
            if (gameObject.tag == "Big Brain")
            {

                //transform.LookAt(player.transform.position);
                //transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                //Debug.Log("rotating enemy");

                //move towards player
                if (distanceToPlayer >= distancetostop && distanceToPlayer < chaseRange)
                {
                    if(ani.GetBool("Chasing") == false)
                    {
                        ani.SetBool("Chasing", true);
                    }

                    transform.position = Vector3.Lerp(transform.position, player.transform.position + LaneChaseOffset, enemySpeed * Time.deltaTime);
                    //Debug.Log("chasing player");


                }
				if(LaneNum != playerLane)
				{
					Vector3 go = new Vector3(transform.position.x, player.transform.position.y + LaneChaseOffset.y,transform.position.z);
					transform.position = Vector3.Lerp(transform.position, go, enemySpeed * Time.deltaTime);
				}//else  if(currentRB.gameObject.tag == "Whatever the tag of the enemy")


            }
            //Brain Bear movement / (PROJECTILE ENEMIES)
            else if (gameObject.tag == "Brain Bear")
            {
                enemyHeight = 1f;

                if (LaneNum != playerLane)
                {
                    Vector3 go = new Vector3(transform.position.x, player.transform.position.y, transform.position.z); // + LaneChaseOffset
                    transform.position = Vector3.Lerp(transform.position, go, enemySpeed * Time.deltaTime);
                }

                    //if the player is further than further than minimal range and within shooting range
                    if (distanceToPlayer >= distancetostop && distanceToPlayer < shootingRange)
                {
                    projectilePos = transform.position;
                    //Debug.Log("ready to fire");
                    if (player.transform.position.x <= transform.position.x)  //player is to the left and its time to fire.
                    {

                        playerOnLeft = true;
                        if (Time.time > nextFire)
                        {
                            //fire left
                            nextFire = Time.time + fireRate;
                            //ani.SetBool("BrainBear_Attack", true);
                            // Debug.Log("Firing left");
                            //ani.SetTrigger("BrainBear_Attacks");
                            projectilePos += new Vector2(-1f, -0.43f); //manipulate this to determine where the projectile will spawn in relation to enemies position
                            P = Instantiate(projectileLeft, projectilePos, Quaternion.identity);
                            P.GetComponent<Projectile>().SetLane(LaneNum); //instantiate left-shooting-beam
                        }
                        else
                        {
                          //  ani.SetBool("BrainBear_Idle", true);

                        }
                    }
                    else //player is on right
                    {
                        playerOnLeft = false;

                        if (Time.time > nextFire)
                        {
                            //fire right
                            nextFire = Time.time + fireRate;
                       //     ani.SetBool("BrainBear_Attack", true);
                            // Debug.Log("Firing left");
                            projectilePos += new Vector2(1f, 0.43f); //manipulate this to determine where the projectile will spawn in relation to enemies position
                            P =Instantiate(projectileRight, projectilePos, Quaternion.identity);
                            P.GetComponent<Projectile>().SetLane(LaneNum); //instantiate left-shooting-beam
                        }
                        else
                        {
                       //     ani.SetBool("BrainBear_Idle", true);
                        }
                    }
                    //Movement
                    if (distanceToPlayer < minimumShootingRange) //player is getting close to enemy
                    {
                        Vector3 retreatPos;
                        if (playerOnLeft)
                        {
                            retreatPos = new Vector3(transform.position.x + 12f, transform.position.y, transform.position.z);//move right (away from player)
                        }
                        else
                        {
                            retreatPos = new Vector3(transform.position.x - 12f, transform.position.y, transform.position.z);//move left (away from player)
                        }

                        transform.position = Vector3.Lerp(transform.position, retreatPos, projectileEnemySpeed * Time.deltaTime);
                        //Debug.Log("player is too close...retreating");

                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, player.transform.position+LaneChaseOffset, projectileEnemySpeed * Time.deltaTime);
                        //Debug.Log("player is not too close...chasing a little");
                    }


                }

                //else  if(currentRB.gameObject.tag == "Whatever the tag of the enemy")
                //how you want it to move.
                //if (playerLane != LaneNum)
                //{
                //    float playerypos = player.transform.position.y;
                //    Debug.Log("player is close and in a different lane");

                //    if (playerLane < LaneNum)
                //    {
                //        transform.Translate(Vector3.down * Time.deltaTime);
                //        Debug.Log("going down");
                //    }
                //    else if (playerLane > LaneNum)
                //    {
                //        transform.Translate(Vector3.up * Time.deltaTime);
                //        Debug.Log("going up");
                //    }

                //}

            }

        }
        //player not on level....retreat to original position
        else
        {
            //Debug.Log("RETREATING");
           // ani.SetBool("Chasing",false);
            transform.position = Vector3.Lerp(transform.position, startingPosition, enemySpeed * Time.deltaTime);

           // Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
            //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 3.5f);
        }
    }
    public void isPlayerOnLevel()
    {
        if (Mathf.Abs(transform.position.y - player.transform.position.y) < 2)
        {
            playerOnLevel = true;
            //Debug.Log("Player is on level");

        }
        else
        {
            playerOnLevel = false;
           // Debug.Log("Player left level");

        }

    }
	public void LightUp(bool n)
	{
		marker.SetActive(n);
	}
    //public void CheckFacingPlayer() {
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)){
    //        if (hit.collider.name / tag == "what you're asking the player to face") {
    //            playerFacing = true;
    //        } else {
    //            playerFacing = false;
    //        }
    //    }
    //}
    IEnumerator wait()
	{
		yield return new WaitForSeconds(1);
		//ani.SetBool("Attacking", false);
	}
}
