using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour {
public GameObject manager;
public GameObject signal;
private bool move = false;
	void Start()
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		//display button to press to go to next section
		if (other.gameObject.name == "Player")
		{
			move = true;
			signal.SetActive(true);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		//remove button to press to go to next section
		if (other.gameObject.name == "Player")
		{
			move = false;
			signal.SetActive(false);
		}
	}
	// void OnTriggerStay2D(Collider2D other)
	// {
	// 	if (other.gameObject.name == "Player")
	// 	{
	// 		Debug.Log("reconized player");
	// 		if (Input.GetKeyDown(KeyCode.E))
	// 		{
	// 			Debug.Log("Key E is down");
	// 			manager.GetComponent<LevelManager>().LevelTransition(gameObject);
	// 		}
	// 	}
	// }
	private void Update() {
		if (move == true)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				//Debug.Log("Key E is down");
				manager.GetComponent<LevelManager>().LevelTransition(gameObject);
			}
		}
	}
}
