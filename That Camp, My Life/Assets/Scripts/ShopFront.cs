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
		if (other.gameObject.tag == "Player")
			camera.offset = desiredOffset;
	}

	void OnTriggerExit2D(Collider2D other)
	{	
		if (other.gameObject.tag == "Player")
			camera.offset = defaultOffset;
	}
}
