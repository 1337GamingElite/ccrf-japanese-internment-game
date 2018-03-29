using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour {

	public int sceneIndex;
	public GameObject pressE;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			pressE.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			pressE.SetActive(false);
		}
	}

	void Update()
	{
		if (Input.GetButtonDown("Interact") && pressE.active)
		{
			Debug.Log("Hi");
		}
	}

}
