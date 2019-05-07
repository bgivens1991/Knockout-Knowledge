using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public float speed = 0.125f;
//	public float movmentMult = 5f;
	public int moveAmount = 1;


    private Rigidbody2D rb2d;
	private Transform move;
	private Vector3 go;
	private Vector3 difference;
	private Vector3 GroundPos;
	private Vector3 JumpPeak;
	private Vector3 currentJump;
	private SpriteRenderer spriteR;
	private bool jumping = false;
	private bool hitPeak = false;
	public bool inRange = false;
	private GameObject currentEnemy;
	public int PlayerAttackDamage = 25;
	public bool facingRight = true;
    public int fightCount = 0;
	public bool allowedToMove;
	// Use this for initialization
	void Start () {
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		//allowedToMove = false;
		//rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(allowedToMove == true)
			{
			go = transform.position;
			if(Input.GetKey(KeyCode.A))
			{
				facingRight = false;
			}
			if(Input.GetKey(KeyCode.D))
			{
				facingRight = true;
			}
			if(facingRight)
			{
				gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(.06f, -.12f);
			}
			else
			{
				gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-.06f, -.12f);
			}
			if((Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.W))&& jumping == false)
			{
				difference = new Vector3(-moveAmount,moveAmount,0);
				go =  transform.position + difference;
			}
			else if((Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.S)) && jumping == false)
			{
				difference = new Vector3(-moveAmount,-moveAmount,0);
				go =  transform.position + difference;
			}
			else if((Input.GetKey(KeyCode.D))&&(Input.GetKey(KeyCode.W)) && jumping == false)//------------
			{
				difference = new Vector3(moveAmount,moveAmount,0);
				go =  transform.position + difference;
			}
			else if((Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.D))&& jumping == false )//---------
			{
				difference = new Vector3(moveAmount,-moveAmount,0);
				go =  transform.position + difference;
			}
			else if(Input.GetKey(KeyCode.A))
			{
				difference = new Vector3(-moveAmount,0,0);
				go =  transform.position + difference;
			}

			else if(Input.GetKey(KeyCode.D))
			{

				difference = new Vector3(-moveAmount,0,0);
				go =  transform.position - difference;
			}
			else if(Input.GetKey(KeyCode.W)&& jumping == false)
			{
				difference = new Vector3(0,moveAmount,0);
				go =  transform.position + difference;
			}

			else if(Input.GetKey(KeyCode.S)&& jumping == false)
			{
				difference = new Vector3(0,-moveAmount,0);
				go =  difference + transform.position;
			}
			transform.position = Vector3.Lerp(transform.position,go,speed*Time.deltaTime);
		}	// if(Input.GetKey(KeyCode.Space))
		// {
		// 	if (jumping == false)
		// 	{
		// 		jumping = true;
		// 		difference = new Vector3(2, 2,0);
		// 		GroundPos = transform.position;
		// 		JumpPeak = difference + transform.position;
		// 	}

		// }
		// if (jumping == true)
		// {
		// 	if (hitPeak == true)
		// 	{
		// 		GroundPos.x = transform.position.x;
		// 		spriteR.transform.position = Vector3.Lerp(spriteR.transform.position,GroundPos,15f*Time.deltaTime);

		// 	}
		// 	else
		// 	{
		// 		JumpPeak.x = transform.position.x;
		// 		spriteR.transform.position = Vector3.Lerp(spriteR.transform.position,JumpPeak,15f*Time.deltaTime);
		// 		if (spriteR.transform.position == JumpPeak)
		// 			{
		// 				hitPeak = true;
		// 			}
		// 	}
		// 	if (spriteR.transform.position == GroundPos && hitPeak == true)
		// 	{
		// 		jumping = false;
		// 		hitPeak = false;
		// 	}

		// }


	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if( other.gameObject.tag == "Big Brain"||other.gameObject.tag == "Boss"
		||other.gameObject.tag == "Brain Bear")
		{

			inRange = true;
			currentEnemy = other.gameObject;
			target(other.gameObject, inRange);
            fightCount++;
			//Debug.Log("Enemy is in range" + inRange );
		}

	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Big Brain"||other.gameObject.tag == "Boss"
		||other.gameObject.tag == "Brain Bear")
        {

            inRange = false;
			target(other.gameObject , inRange);
            fightCount--;
			//Debug.Log("Exit Enemy is in range" + inRange);
        }
		// if (other.gameObject.tag == "Boss")
        // {

        //     inRange = false;
		// 	target(other.gameObject , inRange);
        //     fightCount--;
		// 	//Debug.Log("Exit Enemy is in range" + inRange);
        // }
    }

	void target(GameObject enemy, bool n)
	{
		if(enemy.tag == "Big Brain" || currentEnemy.tag == "Brain Bear")
		{
			enemy.GetComponent<Enemy>().LightUp(n);
		}
		else if(enemy.tag == "Boss")
		{
			enemy.GetComponent<BossStats>().LightUp(n);
		}


	}
    public void EnemyWithinRange(bool n, GameObject enemy)
	{
		//Debug.Log("Enemy is in range" + n);
		inRange = n;
		currentEnemy = enemy;


	}
	public void Attack(int damage)
	{
		//Debug.Log("InPlayerAttack");
		PlayerAttackDamage = damage;
		if(inRange && (currentEnemy.tag == "Big Brain" || currentEnemy.tag == "Brain Bear"))
		{
			currentEnemy.GetComponent<Enemy>().getHit(PlayerAttackDamage);

		}
		else if(inRange && currentEnemy.tag == "Boss")
		{
			currentEnemy.GetComponent<BossStats>().getHit(PlayerAttackDamage);
		}

	}
    public int getFightCount()
    {
        return fightCount;
    }
	public void CanMove(bool n)
	{
		allowedToMove = n;
		//Debug.Log("can move " + n);
	}
	public bool returnMove()
	{
		return allowedToMove;
	}


}
