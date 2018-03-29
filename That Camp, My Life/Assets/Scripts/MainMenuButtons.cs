using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

	public Slider slider;
	public Text loadingText;

	public void LoadLevel (int sceneIndex)
	{
		PlayerPrefs.DeleteAll();
		StartCoroutine(LoadAsynched(sceneIndex));
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
