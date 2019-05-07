using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
	// public GameObject player;

	// private Vector3 offset;
	// // Use this for initialization
	// void Start () {
	// 	offset = transform.position - player.transform.position;
	// }

	// // Update is called once per frame
	// void LateUpdate () {
	// 	transform.position = player.transform.position + offset;
	// }

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	public Vector3[] lockPoints;
	public string[] Zones;
	public string currentZone;

	void FixedUpdate ()
	{

		Vector3 desiredPosition = target.position;
		//Setting Camera Y for each Zone---------------------
		if (currentZone == Zones[0])
		 {desiredPosition.y = 0f;}
		else if (currentZone == Zones[1])
		 {desiredPosition.y = -5.74f;}
		 else if (currentZone == Zones[2])
		 {desiredPosition.y = -11.25f;}
		 else if (currentZone == Zones[3])
		 {desiredPosition.y = -16.9f;}
		 else if (currentZone == Zones[4])
		 {desiredPosition.y = -22.4f;}
		 //--------------------------------------------------
		desiredPosition = desiredPosition + offset;
		if (desiredPosition.x > -5.85f && desiredPosition.x < 5.25f)
			{
				Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
				transform.position = smoothedPosition;
			}
		//Debug.Log(currentZone);
		// if (currentZone == Zones[0])
		// {
		// 	if (desiredPosition.x > -5.85f && desiredPosition.x < 5.25f)
		// 		{
		// 			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		// 			transform.position = smoothedPosition;
		// 		}
		// }
		// else if (currentZone == Zones[1])
		// {
		// 	if (desiredPosition.x > 17.67f && desiredPosition.x <24.61f)
		// 		{
		// 			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		// 			transform.position = smoothedPosition;
		// 		}
		// }
		// else if (currentZone == Zones[2])
		// {
		// 	if (desiredPosition.x > 38.76f && desiredPosition.x <45.71f)
		// 		{
		// 			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		// 			transform.position = smoothedPosition;
		// 		}
		// }


	}
	public void ChangeZone(int n)
	{
		currentZone = Zones[n];
	}

}
