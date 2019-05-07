using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layering : MonoBehaviour {
	private SpriteRenderer sprite;
	private int LaneNum;
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
	void Update ()
	{
		switch (LaneNum)
		{
			case 1:
				sprite.sortingLayerName = "LowLane";
				break;
			case 2:
				sprite.sortingLayerName = "MidLane";
				break;
			case 3:
				sprite.sortingLayerName = "HighLane";
				break;
		}
	}
}
