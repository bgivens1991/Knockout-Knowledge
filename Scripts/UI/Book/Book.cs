using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {

	Animator ani;

	 void Start()
	 {
		 ani = GetComponent<Animator>();
	 }
	public void OpenBook()
	{
		ani.SetBool("OpenBook",true);
	}
	public void ChangePage()
	{
		ani.SetBool("ChangePage",true);
		//ani.SetBool("ChangePage",false);
	}
	public void CloseBook()
	{
		ani.SetBool("OpenBook",false);
	}
}
