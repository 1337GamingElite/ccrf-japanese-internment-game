using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomBed : MonoBehaviour {

	public GameObject pressE;
	public Animator fade;
	public Animator twoYears;
	bool nearBed = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("ShopperDone", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
		{
			nearBed = true;
			pressE.SetActive (true);
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("ShopperDone", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
		{
			nearBed = true;
			pressE.SetActive (true);	
		}

		if (PlayerPrefs.GetInt("SleptFirstDay", 0) == 1)
		{
			nearBed = false;
			pressE.SetActive (false);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && PlayerPrefs.GetInt("ShopperDone", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
		{
			nearBed = false;
			pressE.SetActive (false);
		}
	}

	void Update()
	{
		if (Input.GetButtonDown("Interact") && nearBed)
		{
			//Debug.Log ("Go to sleep");
			FindObjectOfType<CameraFollow> ().isCutscene = true;
			fade.Play ("FadeOut");
			StartCoroutine (TwoYearSeq ());
		}	
	}

	IEnumerator TwoYearSeq()
	{
		PlayerPrefs.SetInt ("SleptFirstDay", 1);
		yield return new WaitForSeconds (1f);
		twoYears.Play ("TwoYearsFadeIn");
		yield return new WaitForSeconds (5f);
		twoYears.Play ("TwoYearsFadeOut");
		yield return new WaitForSeconds (1f);
		fade.Play ("FadeIn");
		FindObjectOfType<CameraFollow> ().isCutscene = false; 
	}
		
}
