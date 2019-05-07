using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject player;
	public GameObject camera;
	public GameObject[] sections;
	//public GameObject[] Player_SpawnZones;
	public GameObject[] Camera_SpawnZones;
	public Vector3 Player_SpawnZones_LeftSideOffset;
	public Vector3 Player_SpawnZones_RightSideOffset;
	public Vector3 Camera_SpawnZones_LeftSideOffset;
	public Vector3 Camera_SpawnZones_RightSideOffset;
	public GameObject[] spawnZones;
	//private GameObject currentLevelSection;
	//private GameObject[] nextLevelSection;
	private string currentLevelName;
	public int index = 0;

	private bool transition;
	public bool SpawnLeft = true;
	// Use this for initialization
	void Start () {
		// Player_SpawnZones_LeftSideOffset = new Vector3(9.7f,0f,0f);
		// Player_SpawnZones_RightSideOffset = new Vector3(8.5f,0f,0f);
		// Camera_SpawnZones_LeftSideOffset = new Vector3(4.16f,-1.29f,10f);
		// Camera_SpawnZones_RightSideOffset = new Vector3(2.67f,1.29f,-10f);
		//currentLevelSection = player.GetComponent<playerStatus>().returnLevelSection();
		moveToLevel(index,"spawn");
		//currentLevelSection = sections[index];
		//nextLevelSection = new GameObject[3];
		//nextLevelSection[0] = sections[index +1];
		camera.GetComponent<cameraController>().ChangeZone(index);
	}
	string returnLevel()
	{
		return "" ;
	}
	void Update()
	{

	}
	public void LevelTransition(GameObject door)
	{


			if (door.name == "Left_Door")
			{
				//currentLevelSection = "LeftSection";
				moveToLevel(--index,"rightSide");
				camera.GetComponent<cameraController>().ChangeZone(index);
			}
			else if (door.name == "Right_Door")
			{
				//currentLevelSection = "RightSection";
				moveToLevel(++index ,"leftSide");
				camera.GetComponent<cameraController>().ChangeZone(index);
			}
			else if (door.name == "Boss_Door")
			{
				//currentLevelSection = "Boss";
				index = index + 2;
				moveToLevel(index,"Boss");
				camera.GetComponent<cameraController>().ChangeZone(sections.Length-1);
			}
			else if (door.name == "Study_Door")
			{
				//currentLevelSection = "Study";
				moveToLevel(++index,"Study");
				camera.GetComponent<cameraController>().ChangeZone(sections.Length-2);
			}


	}
	void moveToLevel(int n , string side)
	{
		//currentLevelSection = sections[n];
		switch (side)
		{
			case "leftSide":
			//player.transform.position = Player_SpawnZones[n].transform.position + new Vector3(0.0f,1.0f,0.0f);
			player.transform.position = spawnZones[n].transform.position - Player_SpawnZones_LeftSideOffset;
			camera.transform.position = spawnZones[n].transform.position - Camera_SpawnZones_LeftSideOffset;
			break;
			case "rightSide":
			//player.transform.position = Player_SpawnZones[n].transform.position;
			player.transform.position = spawnZones[n].transform.position + Player_SpawnZones_RightSideOffset;
			camera.transform.position = spawnZones[n].transform.position + Camera_SpawnZones_RightSideOffset;
			break;
			case "Boss":
			player.transform.position = spawnZones[n].transform.position - Player_SpawnZones_LeftSideOffset;
			camera.transform.position = spawnZones[n].transform.position - Camera_SpawnZones_LeftSideOffset;
			break;
			case "Study":
			player.transform.position = spawnZones[n].transform.position + Player_SpawnZones_RightSideOffset;
			camera.transform.position = spawnZones[n].transform.position + Camera_SpawnZones_RightSideOffset;
			break;
			case "Spawn":
			if (SpawnLeft == true)
			{
				//player.transform.position = Player_SpawnZones[n].transform.position;
				player.transform.position = spawnZones[n].transform.position - Player_SpawnZones_LeftSideOffset;
				camera.transform.position = spawnZones[n].transform.position - Camera_SpawnZones_LeftSideOffset;
			}
			else
			{
				//player.transform.position = Player_SpawnZones[n].transform.position;
				player.transform.position = spawnZones[n].transform.position + Player_SpawnZones_LeftSideOffset;
				camera.transform.position = spawnZones[n].transform.position + Camera_SpawnZones_RightSideOffset;
			}
			break;
			default:
			break;
		}


	}
}

