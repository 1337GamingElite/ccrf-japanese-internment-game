using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerStartDialogue : MonoBehaviour {

	public string TagThatTriggers;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == TagThatTriggers)
		{
			GetComponent<DialogueTrigger>().Trigger();
		}
	}

}
