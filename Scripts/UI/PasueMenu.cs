using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasueMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject bookText;
	public GameObject bookTytle;

	// void Update () {
	// 	if (Input.GetKeyDown(KeyCode.Escape))
	// 	{
	// 		if (GameIsPaused)
	// 		{
	// 			Resume();
	// 		}
	// 		else
	// 		{
	// 			Pause();
	// 		}
	// 	}

	// }
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		bookText.SetActive(false);
		bookTytle.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		bookText.SetActive(true);
		bookTytle.SetActive(true);
		//Stopping Time!!!!!!!!!!!!!!!!
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		//SceneManager.LoadScene("Menu");
	}
	public void QuitGame()
	{
		Application.Quit();
	}

}
