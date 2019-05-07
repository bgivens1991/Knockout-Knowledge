using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnimation : MonoBehaviour {

	Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
	}
	public void StartAnimation()
	{
		ani.SetTrigger("Wake");
	}
}
