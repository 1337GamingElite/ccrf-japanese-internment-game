using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBarManager : MonoBehaviour {

	public CameraFollow camera;
	public Animator anim;

	[SerializeField]
	private bool start;

	// Use this for initialization
	void Start () {
		start = camera.isCutscene;
		//Debug.Log(start);
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.isCutscene)
		{
			anim.Play("BlackBarsIn");
			start = true;
		}
		if (!camera.isCutscene)
		{	
			if(start)
				anim.Play("BlackBarsOut");
		}
	}
}
