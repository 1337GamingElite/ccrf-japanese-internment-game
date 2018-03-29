using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

	public string name;

	public Sprite profilePic;

	[TextArea(3, 10)]
	public string[] lines;

}
