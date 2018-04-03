using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStands : MonoBehaviour {

	public GameObject fishAcq;
	public GameObject pressE;
	bool inFishStand = false;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("HasFish", 0) == 1)
		{
			fishAcq.SetActive(true);	
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (PlayerPrefs.GetInt("PlayerMetShopper", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
			{
				inFishStand = true;
				pressE.SetActive(true);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (PlayerPrefs.GetInt("PlayerMetShopper", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
			{
				inFishStand = false;
				pressE.SetActive(false);
			}
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Interact") && inFishStand && PlayerPrefs.GetInt("HasFish", 0) == 0)
		{
			PlayerPrefs.SetInt("HasFish", 1);
			fishAcq.SetActive(true);
			// Play sound
		}

		if (PlayerPrefs.GetInt("SleptFirstDay", 0) == 1)
		{
			fishAcq.SetActive (false);
		}
	}

}
