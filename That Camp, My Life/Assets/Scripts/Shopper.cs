using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour {

	Animator anim;
	bool triggered = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if (PlayerPrefs.GetInt ("SleptFirstDay", 0) == 1)
			Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("NewspaperComment", 0) == 1 && !triggered && PlayerPrefs.GetInt("ShopperIntro", 0) == 0)
		{
			triggered = true;
			anim.Play("ShopperIn");
		}
		if (PlayerPrefs.GetInt("ShopperIntro", 0) == 1 && PlayerPrefs.GetInt("ShopperDone", 0) == 0)
		{
			anim.Play("ShoperFrontDesk");
		}

		if (PlayerPrefs.GetInt("ShopperDone", 0) == 1 && PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
		{
			anim.Play("ShopperLeave");
		}
	}
}
