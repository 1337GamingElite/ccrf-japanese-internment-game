using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToBedTrigger : MonoBehaviour {

	public int sceneIndex;

	public GameObject blackFade;

	Animator anim;
	Image black;

	// Use this for initialization
	void Start () {
		anim = blackFade.GetComponent<Animator>();
		black = blackFade.GetComponent<Image>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Shopper")
		{
			StartCoroutine(FadeOutToScene(sceneIndex));
		}
	}

	IEnumerator FadeOutToScene(int index)
	{
		anim.SetBool("Fade", true);
		yield return new WaitUntil(() => black.color.a == 1);
		SceneManager.LoadScene(index);
	}

}
