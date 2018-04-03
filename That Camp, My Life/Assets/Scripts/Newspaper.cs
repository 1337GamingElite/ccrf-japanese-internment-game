using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

	public Animator newspaper;
	public GameObject pressE;
	bool onPaper = false;

	void Start()
	{
		if (PlayerPrefs.GetInt("ReadPaper", 0) == 1)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			pressE.SetActive(true);
			onPaper = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			pressE.SetActive(false);
			onPaper = false; 
		}
	}

	void Update()
	{
		if (Input.GetButtonDown("Interact") && pressE.active && onPaper)
		{
			//Debug.Log("Open Paper");
			FindObjectOfType<CameraFollow>().isCutscene = true;
			newspaper.Play("NewspaperIn");
			Destroy(this.gameObject);
		}
	}

}
