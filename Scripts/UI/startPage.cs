using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPage : MonoBehaviour {

	public void hide()
	{
		gameObject.SetActive(false);
	}
	public void Unhide()
	{
		gameObject.SetActive(true);
	}
}
