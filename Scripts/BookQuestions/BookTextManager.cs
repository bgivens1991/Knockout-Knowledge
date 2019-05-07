using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookTextManager : MonoBehaviour {

	public Text	nameText;
	public Text QuestionText;
	public GameObject player;
	private BookText HistoryText;
	public int questionNumber = 0;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartText(BookText text)
	{
		if(sentences == null)
		{
			sentences = new Queue<string>();
		}
		HistoryText = text;

		//Debug.Log("Starting Conversation with" + dialogue.name);
		nameText.text = text.Topic;
		if(sentences.Count > 0)
			sentences.Clear();
		foreach (string sentence in text.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();

	}
	public void DisplayNextSentence()
	{
		// questionNumber++;
		// if(sentences.Count == questionNumber)
		// {
		// 	questionNumber = 0;
		// }
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		//Debug.Log(sentence);
		//string sentence = sentences[questionNumber];
		QuestionText.text = sentence;
		//sentences.Enqueue(sentence);
	}
	public void EndDialogue()
	{
		StartText( HistoryText);
		//Debug.Log("End of Conversation ");
		//dialogueBox.SetActive(false);
		//speaker.GetComponent<Introduction>().Conversation(false);

	}
}
