using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour {

	public GameObject player;
	public Vector3 playerOffset;
	public float RangedXOffset = .5f;
	Vector3 RangedOffset;
	public float speed;
	public GameObject projectile;
	float currentHP;
	bool LeftSide;
	bool CombatType; // True for Ranged Combat and False for melee Combat
	SpriteRenderer sprite;
	public float fireRate = 0.5f;
    public float nextFire = 0.0f;
	public Vector3 projectilePos;
	public bool FinalBoss;

	bool canAttack = false;
    bool PlayerWithinRange;
    int attackCounter = 0;
	bool quizing;
	Vector3 Go;
	int LaneNum;
	public GameObject projectileRight, projectileLeft;
	GameObject P;


	// Use this for initialization
	void Start () {
		quizing =true;
		sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {

		if(quizing == false)
		{
			sprite.flipX = !CheckSide();
			Go = combatMovement();
			transform.position = Vector3.Lerp(transform.position,Go,speed*Time.deltaTime);
			if(transform.position.x >= 8)
			{
				transform.position = new Vector3(8,transform.position.y,transform.position.z);
			}
		}
		 if(canAttack)
        {
             attackCounter++;
                if(attackCounter%100 == 0)
                {
                    //ani.SetBool("Attacking", true);
                    Attack();
                }
                if(attackCounter >= 1000)
                {
                    attackCounter = 0;
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
	}

	Vector3 combatMovement()
	{
		Vector3 temp;
		CheckHP();
		if(FinalBoss)
		{
			temp = new Vector3 (player.transform.position.x,gameObject.transform.position.y,0);
			 if (Time.time > nextFire)
                        {
                            //fire left
                            nextFire = Time.time + fireRate;
                            //ani.SetBool("BrainBear_Attack", true);
                            // Debug.Log("Firing left");
							projectilePos = gameObject.transform.position + new Vector3(0f, 0f, 0f);
                            //manipulate this to determine where the projectile will spawn in relation to enemies position
                            P = Instantiate(projectileLeft, projectilePos, Quaternion.identity);
                            P.GetComponent<Projectile>().SetLane(player.GetComponent<playerStatus>().returnLane()); //instantiate left-shooting-beam
							projectilePos = gameObject.transform.position + new Vector3(0f, 0f, 0f);
                            //manipulate this to determine where the projectile will spawn in relation to enemies position
                            P = Instantiate(projectileLeft, projectilePos, Quaternion.identity);
                            P.GetComponent<Projectile>().SetLane(player.GetComponent<playerStatus>().returnLane()); //instantiate left-shooting-beam
							projectilePos = gameObject.transform.position + new Vector3(0f, 0f, 0f);
                            //manipulate this to determine where the projectile will spawn in relation to enemies position
                            P = Instantiate(projectileLeft, projectilePos, Quaternion.identity);
                            P.GetComponent<Projectile>().SetLane(player.GetComponent<playerStatus>().returnLane()); //instantiate left-shooting-beam
                        }
						return temp;
		}
		if(CombatType) //melee
		{
			RangedOffset = new Vector3(2,0,0);
			temp = player.transform.position + playerOffset + RangedOffset;
		}
		else // ranged
		{
			//Debug.Log("RangeBattle");
			RangedOffset = new Vector3(RangedXOffset,0,0);
			if(CheckSide())
			{
				temp = player.transform.position + playerOffset + RangedOffset;
				 if (Time.time > nextFire)
                        {
                            //fire left
                            nextFire = Time.time + fireRate;
                            //ani.SetBool("BrainBear_Attack", true);
                            // Debug.Log("Firing left");
							projectilePos = gameObject.transform.position + new Vector3(1f, 0f, 0f);
                            //manipulate this to determine where the projectile will spawn in relation to enemies position
                            P = Instantiate(projectileLeft, projectilePos, Quaternion.identity);
                            P.GetComponent<Projectile>().SetLane(player.GetComponent<playerStatus>().returnLane()); //instantiate left-shooting-beam
                        }
			}
			else
			{
				temp = player.transform.position + playerOffset - RangedOffset;
			}
		}
		return temp;
	}
	void CheckHP()
	{
		//currentHP = //retive hp
		currentHP = gameObject.GetComponent<BossStats>().ReturnHP();
		if(currentHP <= 15)
		{
			CombatType = false;
			gameObject.GetComponent<BossStats>().SetCombatType(false);
		}
	}
	public bool CheckSide()
	{
		if(player.transform.position.x <= gameObject.transform.position.x)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public void SetQuiz(bool n)
	{
		quizing = n;
	}
	public bool ReturnCombatType()
	{
		return CombatType;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "Player")
		{

			col.gameObject.GetComponent<playerMove>().EnemyWithinRange(false, gameObject);
            canAttack = false;
		}
	}
	public void Attack()
    {
        Debug.Log("attacking");
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
	IEnumerator wait()
	{
		yield return new WaitForSeconds(1);
		//ani.SetBool("Attacking", false);
	}




}
