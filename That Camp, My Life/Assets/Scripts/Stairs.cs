using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour {

	public int sceneIndex;
	public GameObject pressE;
	bool onStairs = false;

	public GameObject blackFade;

	Animator anim;
	Image black;

	private void Start()
	{
		anim = blackFade.GetComponent<Animator>();
		black = blackFade.GetComponent<Image>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("ShopperDone", 0) == 0)
		{
			pressE.SetActive(true);
			onStairs = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("ShopperDone", 0) == 0)
		{
			pressE.SetActive(false);
			onStairs = false;
		}
	}

	void Update()
	{
		if (Input.GetButtonDown("Interact") && pressE.active && onStairs)
		{
			//Debug.Log("Hi");
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
