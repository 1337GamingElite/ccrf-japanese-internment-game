using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperClose : MonoBehaviour {

	Animator newspaper;

	void Start()
	{
		newspaper = this.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Animator>(); 
	}

	public void CloseNewspaper()
	{
		newspaper.Play("NewspaperOut");
		PlayerPrefs.SetInt("ReadPaper", 1);
	}

}
