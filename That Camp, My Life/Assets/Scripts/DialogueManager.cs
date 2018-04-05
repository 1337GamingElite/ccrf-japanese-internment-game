using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameTag;
	public Text diaText;
	public Image profile;
	Queue<string> lines;

	public string saveStateName;

	Animator anim;

	// Use this for initialization
	void Start () {
		lines = new Queue<string>();
		anim = profile.gameObject.GetComponent<Animator>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		//Debug.Log("starting convo w/" + dialogue.name);
		profile.sprite = dialogue.profilePic;
		anim.SetBool("IsOpen", true);
		nameTag.text = dialogue.name;
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
		//Debug.Log(sentence);
		StopAllCoroutines();
		StartCoroutine(TypeLines(sentence));
	}

	IEnumerator TypeLines (string sentence)
	{
		diaText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			diaText.text += letter;
			yield return new WaitForSeconds(0.03f);
		}
	}

	void EndDialogue()
	{
		FindObjectOfType<CameraFollow>().isCutscene = false;
		if (saveStateName != null)
		{
			PlayerPrefs.SetInt(saveStateName, 1);
			saveStateName = null;
		}
		anim.SetBool("IsOpen", false);
	}

}
