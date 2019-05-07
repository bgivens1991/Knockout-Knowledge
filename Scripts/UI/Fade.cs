using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer rend;
	Color clear;
	public GameObject flash;
	float z = 1;
	bool go = true;
	void Start () {
		rend = flash. GetComponent<SpriteRenderer>();
		clear = rend.color;
	}

	// Update is called once per frame
	void Update () {
		if(go == true)
		{
			z = z - 0.01f;
				clear.a = z;
				rend.color = clear;
				if (z < 0)
				{
					go = false;
				}
		}
	}
}
