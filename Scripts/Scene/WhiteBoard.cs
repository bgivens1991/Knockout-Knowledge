using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoard : MonoBehaviour {

public GameObject signal;
public GameObject PasueMenu;
bool move;
	void OnTriggerEnter2D(Collider2D other)
	{
		//display button to press to go to next section
		if (other.gameObject.name == "Player")
		{
			signal.SetActive(true);
			move = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		//remove button to press to go to next section
		if (other.gameObject.name == "Player")
		{
			signal.SetActive(false);
			move = false;
		}
	}

	private void Update() {
		if (move == true)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				Debug.Log("Key E is down");
				PasueMenu.GetComponent<PasueMenu>().Pause();
			}
		}
	}
}
