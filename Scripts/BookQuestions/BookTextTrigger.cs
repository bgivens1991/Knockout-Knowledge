using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTextTrigger : MonoBehaviour {

	public BookText text;
	public GameObject user;

	public void TriggerText()
	{
		user.GetComponent<BookTextManager>().StartText(text);
	}
}
