using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

	public Slider slider;
	public Text loadingText;
	public GameObject settingsMenu;
	public GameObject regularUI;
	bool settingsOn = false;

	public void LoadLevel (int sceneIndex)
	{
		PlayerPrefs.DeleteAll();
		StartCoroutine(LoadAsynched(sceneIndex));
	}

	public void ToggleSettingsMenu()
	{
		if (!settingsOn){
			settingsOn = true;
			settingsMenu.SetActive (true);
			regularUI.SetActive (false);
		} else if (settingsOn)
		{
			settingsOn = false;
			settingsMenu.SetActive (false);
			regularUI.SetActive (true);
		}
	}

	IEnumerator LoadAsynched (int sceneIndex)
	{
		AsyncOperation oper = SceneManager.LoadSceneAsync(sceneIndex);
		slider.gameObject.SetActive(true);

		while(!oper.isDone)
		{
			float progress = Mathf.Clamp01(oper.progress / 0.9f);
			slider.value = progress;
			//Debug.Log(Mathf.RoundToInt(progress * 100f) + "%");
			loadingText.text = Mathf.RoundToInt(progress * 100f) + "%";

			yield return null;
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
}
