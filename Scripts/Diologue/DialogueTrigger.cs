using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public GameObject user;




	public void TriggerDialogue()
	{
		user.GetComponent<DiologueManager>().StartDialogue(dialogue);
	}
	public void DeleteDialogue()
	{
		user.GetComponent<DiologueManager>().EndDialogue();
	}


	// void Start()
	// {
	// 	TriggerDialogue();
	// }
}
