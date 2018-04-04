using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellWindows : MonoBehaviour {

	public GameObject pressE;
	public int sceneIndex;
	bool inFrontOfWindow;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			inFrontOfWindow = true;
			pressE.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			inFrontOfWindow = false;
			pressE.SetActive(false);
		}
	}

	void Update()
	{
		if (inFrontOfWindow && Input.GetButtonDown("Interact"))
		{
			Debug.Log("Window Looking Scene");
		}
	}

}
