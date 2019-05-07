using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.name == "Player")
		{
			col.gameObject.GetComponent<playerStatus>().AddPage();
			Destroy(gameObject);
		}
	}
}
