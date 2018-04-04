using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsidePrisonTransition : MonoBehaviour {

	public Animator fade;
	public Animator text;
	public int sceneIndex;
	bool transitioned = false;

	// Update is called once per frame
	void Update()
	{
		if (PlayerPrefs.GetInt("PrisonIntro", 0) == 1 && !transitioned)
		{
			transitioned = true;
			FindObjectOfType<CameraFollow>().isCutscene = true;
			fade.Play("FadeOut");
			StartCoroutine(Transition(sceneIndex));
		}
	}

	IEnumerator Transition(int index)
	{
		yield return new WaitForSeconds(1f);
		text.Play("OutsideTransIn");
		yield return new WaitForSeconds(7.5f);
		text.Play("OutsideTransOut");
		yield return new WaitForSeconds(1.2f);
		SceneManager.LoadScene(index);
	}
}

