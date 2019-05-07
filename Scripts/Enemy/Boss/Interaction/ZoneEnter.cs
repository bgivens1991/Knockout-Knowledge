using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEnter : MonoBehaviour {

	public GameObject boss;
	bool enter = false;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(enter)
		{
			return;
		}
		else
		{
			if (other.gameObject.name == "Player")
			{
				enter = true;
				boss.GetComponent<OnPlayerEnter>().EnterFlag(true);

			}

		}
	}
}
