using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupButtons : MonoBehaviour {

	public GameObject dialogueBox;
	public void dialogueBoxStatus(bool n)
	{
		dialogueBox.SetActive(n);
	}
}
