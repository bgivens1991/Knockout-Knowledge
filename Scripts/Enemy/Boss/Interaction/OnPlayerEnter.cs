using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerEnter : MonoBehaviour {

	public GameObject EnterZone;
	public GameObject player;
	private bool playerEntered;
	private bool InConversation;
	public Vector3 QuizPosition;
	public Vector3 FightingPosition;
	private Vector3 Go;
	private Vector3 buffer;
	private bool RestainedMove;
	public float speed = 0.125f;

	// Use this for initialization
	void Start () {
		buffer = new Vector3(1,0,0);
		playerEntered = false;
		InConversation =false;
		RestainedMove = false;
	}

	// Update is called once per frame
	void Update () {

		if(RestainedMove)
		{
			if((transform.position.x <= Go.x + buffer.x || transform.position.x == Go.x) && InConversation == false)
			{
				Debug.Log("StartTalking");
				ConversationFlag(true);
			}
			transform.position = Vector3.Lerp(transform.position,Go,speed*Time.deltaTime);

		}

	}
	public void EnterFlag(bool n)
	{
		playerEntered = n;
		if(playerEntered)
		{
			SetMove(QuizPosition);
			RestainedMove = true;
			player.GetComponent<playerMove>().CanMove(false);
		}
	}
	public void ConversationFlag(bool n)
	{
		InConversation = n;
		if(InConversation == false)
		{//begin battle
			//SetMove(FightingPosition);
			RestainedMove = false;


		}
		else
		{
			//begin conversation
			Debug.Log("begin Conversation");
			gameObject.GetComponent<SetupButtons>().dialogueBoxStatus(true);
			gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
		}
	}
	void SetMove(Vector3 n)
	{
		Go = n;
	}
	public void RestoreMovement()
	{
		RestainedMove = false;
		player.GetComponent<playerMove>().CanMove(true);
		gameObject.GetComponent<BossBattle>().SetQuiz(false);

	}
}
