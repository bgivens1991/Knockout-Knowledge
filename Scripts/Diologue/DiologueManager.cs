using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiologueManager : MonoBehaviour {

	public Text	nameText;
	public Text dialogueText;
	public GameObject dialogueBox;
	public GameObject speaker;
	string speakerName;
	public GameObject player;
	public GameObject chair;
	public Text ChoiceA;
	public Text ChoiceB;
	public Text ChoiceC;
	public string[] Awnsers;

	//quiz
	public GameObject Quiz;
	public GameObject QuizPanel;
	public GameObject QuizBtnHide;
	public GameObject BigBoss;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		dialogueBox.SetActive(true);
		//Debug.Log("Starting Conversation with" + dialogue.name);
		nameText.text = dialogue.name;
		speakerName = dialogue.name;
		sentences.Clear();
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		if(speakerName == "Quiz")
		{
			QuizPanel.SetActive(true);
			QuizBtnHide.SetActive(false);
		}

		DisplayNextSentence();

	}
	public void DisplayNextSentence()
	{
		string sentence;
		if(speakerName == "TutorialGuy")
		{
			if(sentences.Count == 4)
			{
				chair.GetComponent<ChairAnimation>().StartAnimation();
				//player.GetComponent<PlayerAnimation>().WakeUp();
				StartCoroutine("wait");

			}
		}

		if(speakerName == "Shiffty Student")
		{
			if(sentences.Count == 3)
			{
				chair.GetComponent<ShifttStudent>().ChangeButtonName();

			}
			if(sentences.Count == 3)
			{
				chair.GetComponent<ShifttStudent>().ChangeButtonName();

			}
		}
		//Quiz-------------
		if(speakerName == "Quiz")
		{
			//Load Question Box
			if(sentences.Count == 0)
			{
				EndDialogue();
				return;
			}
			sentence = sentences.Dequeue();
			dialogueText.text = sentence;
			//Load Awnsers Boxes
			sentence = sentences.Dequeue();
			ChoiceA.text = sentence;
			sentence = sentences.Dequeue();
			ChoiceB.text = sentence;
			sentence = sentences.Dequeue();
			ChoiceC.text = sentence;
			return;
		}

		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		sentence = sentences.Dequeue();
		//Debug.Log(sentence);
		dialogueText.text = sentence;

	}
	public void CheckAwnser(Text T)
	{
		string temp = T.text;
		foreach (string A in Awnsers)
		{
			Debug.Log(temp);
			if(A.Trim().ToLower().Equals(temp.Trim().ToLower())|| A.Trim().ToLower() == temp.Trim().ToLower())
			{
				dialogueText.text = "Correct!!";
				BigBoss.GetComponent<BossStats>().getHit(10);
				//Go Lower Boss HP
				StartCoroutine("wait");
				return;
			}
		}
		dialogueText.text = "Incorrect";
		StartCoroutine("wait");
	}

	public void EndDialogue()
	{

		//Debug.Log("End of Conversation ");
		sentences.Clear();
		dialogueBox.SetActive(false);
		if(speakerName == "TutorialGuy")
		{
			speaker.GetComponent<Introduction>().Conversation(false);
		}
		if(speakerName == "Quiz")
		{
			BigBoss.GetComponent<OnPlayerEnter>().RestoreMovement();
			QuizPanel.SetActive(false);
		}
		if(speakerName == "Professor")
		{
			Quiz.GetComponent<DialogueTrigger>().TriggerDialogue();
		}


	}
	public void Echange(bool n)
	{
		if(n)
		{
			DisplayNextSentence();
			DisplayNextSentence();
			StartCoroutine("wait");

		}
		else
		{
			DisplayNextSentence();
			StartCoroutine("wait");

		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(1);
		if(speakerName == "TutorialGuy")
		{
			player.GetComponent<PlayerAnimation>().WakeUp();
		}
		else if(speakerName == "Quiz")
		{
			DisplayNextSentence();

		}
		else
		{
			EndDialogue();
		}
	}
}
