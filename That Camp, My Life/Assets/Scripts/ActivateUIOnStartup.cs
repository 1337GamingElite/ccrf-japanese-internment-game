using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUIOnStartup : MonoBehaviour {

	public GameObject ui;

	// Use this for initialization
	void Start () {
		ui.SetActive(true);
	}


}
