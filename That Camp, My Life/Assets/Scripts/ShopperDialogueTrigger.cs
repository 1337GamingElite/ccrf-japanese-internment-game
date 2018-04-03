using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperDialogueTrigger : MonoBehaviour {

	CameraFollow cam;
	public GameObject player;

	Animator playerAnim;
	Transform playerTrans;

	public Transform playerPositionDuringDialogue;

	// Use this for initialization
	void Start () {
		cam = FindObjectOfType<CameraFollow>();
		playerAnim = player.GetComponent<Animator>();
		if (PlayerPrefs.GetInt("SleptFirstDay", 0) == 0)
			playerTrans = player.transform;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Shopper")
		{
			//Debug.Log("Talk thy shopper");
			playerTrans.position = playerPositionDuringDialogue.position;
			playerAnim.SetFloat("LastMoveY", -1.0f);
			playerAnim.SetFloat("LastMoveX", 0f);
			cam.player = playerTrans;
			this.gameObject.GetComponent<DialogueTrigger>().Trigger();
		}
	}

}
