using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperCam : MonoBehaviour {

	CameraFollow cam;

	// Use this for initialization
	void Start () {
		cam = FindObjectOfType<CameraFollow>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Shopper" && PlayerPrefs.GetInt("ShopperIntro", 0) == 0)
		{
			cam.isCutscene = true;
			cam.offset = new Vector2(0f, 0f);
			cam.player = collision.gameObject.transform;
		}

	}

}
