using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefocusPlayer : MonoBehaviour {

	CameraFollow cam;
	public Vector2 desiredOffset;
	public Transform player;

	// Use this for initialization
	void Start () {
		cam = FindObjectOfType<CameraFollow>();
	}
	
	public void Refocus()
	{
		cam.player = player;
		cam.offset = desiredOffset;
	}

}
