using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	//private String playerLane;
	private playerStatus playerStat;

	//public GameObject player;
	void Awake() {
		playerStat = GameObject.FindObjectOfType<playerStatus>();

	}
	// void OnTriggerEnter2D(Collider2D col) {
	// 	LaneCheck("Player" , col);
	// 	LaneCheck("Enemy", col);
	// }
	// void OnTriggerStay2D(Collider2D col) {
	// 	LaneCheck("Player", col);
	// 	LaneCheck("Enemy", col);
	// }
	// Update is called once per frame



	// void Update () {

	// }
	// void LaneCheck(string name, Collider2D col)
	// {
	// 	if (name.Equals("Player"))
	// 	{
	// 		if (col.gameObject.name == "Player")
	// 	{
	// 		if (gameObject.name == "LowLane")
	// 		{
	// 			playerStat.UpdateLane(1);
	// 		}
	// 		else if (gameObject.name == "MidLane")
	// 		{
	// 			playerStat.UpdateLane(2);
	// 		}
	// 		else if (gameObject.name == "HighLane")
	// 		{
	// 			playerStat.UpdateLane(3);
	// 		}

	// 	}
	// 	}

	// 	if (name.Equals("Enemy"))
	// 	{

	// 		if (col.gameObject.name == "Enemy")
	// 	{
	// 		Debug.Log("Lane tESST");
	// 		if (gameObject.name == "LowLane")
	// 		{
	// 			col.gameObject.GetComponent<Enemy>().UpdateLane(1);
	// 		}
	// 		else if (gameObject.name == "MidLane")
	// 		{
	// 			col.gameObject.GetComponent<Enemy>().UpdateLane(2);
	// 		}
	// 		else if (gameObject.name == "HighLane")
	// 		{
	// 			col.gameObject.GetComponent<Enemy>().UpdateLane(3);
	// 		}

	// 	}
	// 	}

	// }
}
