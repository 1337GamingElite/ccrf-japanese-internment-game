using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void Trigger()
	{
		FindObjectOfType<CameraFollow>().isCutscene = true;
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
