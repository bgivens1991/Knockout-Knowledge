using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class hideUnhide : MonoBehaviour {
	bool flip;
	public GameObject item1;
	public GameObject item2;
	public GameObject hideItem;
	public float time = 1f;

void Start()
{

}

	public void hide()
	{
		hideItem.SetActive(false);

	}
	public void unHide()
	{
		gameObject.SetActive(true);

	}
	public void unHideOther()
	{
		flip = true;
		StartCoroutine("work");


	}
	public void HideOther()
	{
		flip = true;
		StartCoroutine("work");


	}
	IEnumerator work()
	{
		yield return new WaitForSeconds(time);
		Debug.Log("BOOM");
		item1.SetActive(flip);
		item2.SetActive(flip);
		hide();
	}
}
