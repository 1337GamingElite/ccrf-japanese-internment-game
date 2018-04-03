using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFish : MonoBehaviour {

	public GameObject pressE;
	public GameObject fishAcq;
	bool isGoingToGiveFish = false;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("HasFish", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
		{
			isGoingToGiveFish = true;
			pressE.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("HasFish", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0) 
		{
			isGoingToGiveFish = false;
			pressE.SetActive(false);
		}
	}

	void Update()
	{
		if (isGoingToGiveFish && Input.GetButtonDown("Interact"))
		{
			//Debug.Log("Gave Fish");
			fishAcq.SetActive(false);
			GetComponent<DialogueTrigger>().Trigger();
			Destroy(this.gameObject);
		}
	}

}
