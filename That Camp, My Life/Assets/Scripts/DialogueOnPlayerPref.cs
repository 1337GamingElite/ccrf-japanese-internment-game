using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnPlayerPref : MonoBehaviour {

	public string PlayerPref;
	DialogueTrigger dia;
	bool triggered = false;

	// Use this for initialization
	void Start () {
		dia = GetComponent<DialogueTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt(PlayerPref, 0) == 1 && !triggered)
		{
			triggered = true;
			StartCoroutine(StartDia());
		}
	}

	IEnumerator StartDia()
	{
		yield return new WaitForSeconds(0.3f);
		dia.Trigger();
	}

}
