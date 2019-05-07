using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour {

	public int time = 4;
	bool spin = false;
	bool start = false;
	public GameObject item;
	int t = 1;
	int x = 1;
	int y = 1;
	float z = 0.0f;
	int sceneIndex;
	public GameObject flash;
	SpriteRenderer rend;
	Color clear;

	public void LoadByIndex(int n)
	{
		sceneIndex = n;
		start = true;

		//closeDelay();
		//spinDelay(sceneIndex);
	}
	void Start()
	{
		rend = flash. GetComponent<SpriteRenderer>();
		clear = rend.color;
	}
	void Update()
	{
		if(start == true)
		{
			x++;
			if(x > 100)
			{
				spin = true;
			}
		}
		if(spin == true)
		{
			item.transform.Rotate(new Vector3(0,0,t) * Time.deltaTime, Space.World);
			t = (t +5);
			if (t > 500)
			{
				z = z + 0.01f;
				clear.a = z;
				rend.color = clear;
				if( t > 1000)
				{
					Debug.Log("change level");
					SceneManager.LoadScene(sceneIndex);
				}

			}
		}
	}
	IEnumerator closeDelay()
	{
		yield return new WaitForSeconds(3);
		Debug.Log("end delay");
		spin = true;

	}
	IEnumerator spinDelay( int sceneIndex)
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(sceneIndex);
	}

}
