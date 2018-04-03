using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFront : MonoBehaviour {

	CameraFollow camera;

	Vector2 defaultOffset;

	public Vector2 desiredOffset;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<CameraFollow>();
		defaultOffset = camera.offset;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			camera.offset = desiredOffset;
			if (PlayerPrefs.GetInt ("SleptFirstDay", 0) == 1 && PlayerPrefs.GetInt("QueuedGovernmentGuy", 0) == 0) {
				PlayerPrefs.SetInt ("QueuedGovernmentGuy", 1);
				Debug.Log ("Queue Big Bad Government Guy!!!");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{	
		if (other.gameObject.tag == "Player")
			camera.offset = defaultOffset;
	}
}
