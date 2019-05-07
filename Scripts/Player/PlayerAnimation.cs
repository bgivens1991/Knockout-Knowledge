using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	Animator ani;
	SpriteRenderer sprite;
	int kick = 0;
	int punch = 0;
	int timer = 0;
	bool movement;
	bool inCombat;
	bool inCombo;
	public GameObject player;
	bool canMove;
	public bool pvl1;
	// Use this for initialization
	void Start () {
		inCombat = false;
		ani = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {

		if(pvl1)
		{
			postLevelOne();
			pvl1 =false;
		}
		canMove = player.GetComponent<playerMove>().returnMove();
		if(canMove == true)
		{
			if(Input.GetKeyDown(KeyCode.A))
				{
					sprite.flipX = true;
				}
				if(Input.GetKeyDown(KeyCode.D))
				{
					sprite.flipX = false;
				}
			if (( Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)
			||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)))
			{
				ani.SetBool("Moving",true);
			}
			else
			{
				ani.SetBool("Moving",false);
			}
			if (inCombat == true && Input.GetKeyDown(KeyCode.I))
			{
				if (punch == 0 && timer == 0)
				{
					ani.SetBool("PunchFirst", true);
				}
				inCombo = true;
				ani.SetBool("InCombo",true);
				punch++;
				ani.SetInteger("PunchCombo", punch);
				// timer++;
				// ani.SetInteger("ComboTimer", timer);
			}
			if (inCombat == true && Input.GetKeyDown(KeyCode.O))
			{
				if (punch == 0 && timer == 0)
				{
					ani.SetBool("KickFirst", true);
				}
				inCombo = true;
				ani.SetBool("InCombo",true);
				kick++;
				ani.SetInteger("KickCombo", kick);
				// timer++;
				// ani.SetInteger("ComboTimer", timer);
			}
		}
		// if (timer == 4)
		// 	{
		// 		ani.SetTrigger("KickFirst");
		// 		ani.SetTrigger("PunchFirst");
		// 		inCombo = false;
		// 		ani.SetBool("InCombo",false);
		// 		kick = 0;
		// 		ani.SetInteger("KickCombo", kick);
		// 		punch = 0;
		// 		ani.SetInteger("PunchCombo", punch);
		// 		// timer = 0;
		// 		// ani.SetInteger("ComboTimer", timer);
		// 	}

	}
	public void resetValues()
	{
		ani.SetBool("KickFirst", false);
		ani.SetBool("PunchFirst", false);
		inCombo = false;
		ani.SetBool("InCombo",false);
		kick = 0;
		ani.SetInteger("KickCombo", kick);
		punch = 0;
		ani.SetInteger("PunchCombo", punch);
		// timer = 0;
		// ani.SetInteger("ComboTimer", timer);
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.name == "CombatZone")
		{
			inCombat = true;
			ani.SetBool("Combat",true);
		}
		if (other.gameObject.name == "NonCombatZone")
		{
			inCombat = false;
			ani.SetBool("Combat",false);
		}
	}
	public void WakeUp()
	{
		ani.SetTrigger("WakeUp");
		StartCoroutine("wait");

	}
	public void postLevelOne()
	{
		ani.SetBool("AllreadyWoke",true);
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds(3);
		ani.SetBool("AllreadyWoke",true);
	}
}
