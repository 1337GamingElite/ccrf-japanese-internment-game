using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public string SaveState;

	public void Trigger()
	{
		if (PlayerPrefs.GetInt(SaveState, 0) == 0)
		{
			FindObjectOfType<CameraFollow>().isCutscene = true;
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			if (SaveState != null)
				FindObjectOfType<DialogueManager>().saveStateName = SaveState;
		}
	}

}
