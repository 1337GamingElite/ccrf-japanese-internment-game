using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject pauseMenu;
	bool isPaused;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				UnpauseGame();
			} else if (!isPaused)
			{
				PauseGame();
			}
		}
	}

	void PauseGame()
	{
		Time.timeScale = 0f;
		isPaused = true;
		pauseMenu.SetActive(true);
	}

	public void UnpauseGame()
	{
		Time.timeScale = 1f;
		isPaused = false;
		pauseMenu.SetActive(false);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
