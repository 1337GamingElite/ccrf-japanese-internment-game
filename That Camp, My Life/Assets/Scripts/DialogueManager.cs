using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

	Queue<string> lines;

	// Use this for initialization
	void Start () {
		lines = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		Debug.Log("starting convo w/" + dialogue.name);
		lines.Clear();
		foreach (string sentence in dialogue.lines)
		{
			lines.Enqueue(sentence);
		}

		DisplayNextLine();
	}
	
	public void DisplayNextLine()
	{
		if (lines.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = lines.Dequeue();
		Debug.Log(sentence);
	}

	void EndDialogue()
	{
		Debug.Log("End of convo");
		FindObjectOfType<CameraFollow>().isCutscene = false;
	}

}
