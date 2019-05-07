using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour {

	bool moveR;
	bool inConversation;
	public GameObject player;
	public GameObject button;
	Transform playerT;
	public float Xoffset = 2.0f;
	Vector3 buffer;
	Vector3 offset;
	private Vector3 go;
	bool startedDialogue;
	public float smoothTime = 0.3f;
	bool inCombat;
	Animator ani;
	SpriteRenderer sprite;

	//public float speed = 0.125f;
	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	// void Start () {
	// 	gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
	// 	moveR = false;
	// }


	void Start()
	{
		startedDialogue = false;
		playerT = player.GetComponent<Transform>();
		setOffset();
		player.GetComponent<playerMove>().CanMove(false);
		inConversation = true;
		buffer = new Vector3(1,0,0);
		moveR =false;

		inCombat = false;
		ani = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if( moveR == false)
		{
			sprite.flipX = true;
		}
		if( moveR == true)
		{
			sprite.flipX = false;
		}
		if (transform.position != go)
		{
			transform.position = Vector3.SmoothDamp(transform.position,go,ref velocity, smoothTime);

		}
		if(inConversation == true &&(transform.position.x == go.x || transform.position.x <= go.x + buffer.x))
		{
			if(inConversation == true && startedDialogue == false)
			{


				//Debug.Log("Start Talkin");
				gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
				startedDialogue = true;
			}

		}
		if(inConversation == false && (transform.position.x == go.x || transform.position.x >= go.x - buffer.x))
		{
			if(inConversation == false)
			{
				gameObject.SetActive(false);
				button.SetActive(false);
				player.GetComponent<playerMove>().CanMove(true);
			}
		}

	}

	public void setOffset()
	{
		offset = new Vector3(Xoffset,0,0);
		go = playerT.position + offset;
	}

	public void Conversation(bool n)
	{
		inConversation = n;
		if(inConversation == false)
		{
			moveR = true;
			Xoffset = 10;
			setOffset();
		}
	}
}
