using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

	[SerializeField]
	private float moveSpeed; // Move speed of player

	public CameraFollow camera;
	public string checkForThisPlayerPrefString;

	public Transform secondarySpawn;

	private Rigidbody2D rb2d; // Player's rigidbody

	private Vector2 moveInput; // The movement input
	private Vector2 moveVelocity; // moveInput + moveSpeed

	private Animator anim;

	private bool isMoving;
	private Vector2 lastMove;

	private DialogueTrigger diaTrig;
	[SerializeField]
	private bool DiaglogueOnLoad;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		diaTrig = GetComponent<DialogueTrigger>();
		if (secondarySpawn != null && PlayerPrefs.GetInt(checkForThisPlayerPrefString, 0) == 1)
		{
			this.transform.position = secondarySpawn.position;
		}
		if (DiaglogueOnLoad && diaTrig != null && PlayerPrefs.GetInt(checkForThisPlayerPrefString, 0) != 1)
		{
			diaTrig.Trigger();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		isMoving = false;

		if (!camera.isCutscene)
		{
			moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			moveVelocity = moveInput * moveSpeed;
		}
	}

	void FixedUpdate()
	{
		if (!camera.isCutscene)
		{
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				isMoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			{
				isMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}

			rb2d.velocity = moveVelocity;
			anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
			anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
			anim.SetBool("PlayerMoving", isMoving);
			anim.SetFloat("LastMoveX", lastMove.x);
			anim.SetFloat("LastMoveY", lastMove.y);
		}
		if (camera.isCutscene)
		{
			rb2d.velocity = new Vector2(0f, 0f);
			anim.SetFloat("MoveX", 0);
			anim.SetFloat("MoveY", 0);
			anim.SetBool("PlayerMoving", false);
		}
	}

}
