using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		if (camera.isCutscene && !anim.GetCurrentAnimatorStateInfo(0).IsName("BlackBarsIn"))
		{
			anim.Play("BlackBarsIn");
			start = true;
		}
		if (!camera.isCutscene && !anim.GetCurrentAnimatorStateInfo(0).IsName("BlackBarsOut"))
		{
			if (start)
			{
				anim.Play("BlackBarsOut");
			}
		}
	}
}
