using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public bool isCutscene = false;
	public Transform player;
	public float smoothing;

	public Vector2 offset;

	public bool boundsOn;

	public Vector3 minBounds;
	public Vector3 maxBounds;

	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector2 playerPos = new Vector2(player.position.x, player.position.y);
		Vector2 targetPos = playerPos + offset;
		Vector2 transform2dpos = new Vector2(transform.position.x, transform.position.y);
		Vector2 smoothedPos = Vector2.Lerp(transform2dpos, targetPos, smoothing * Time.deltaTime);

		transform.position = new Vector3(smoothedPos.x, smoothedPos.y, -10f);

		if (boundsOn)
		{
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
				Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
				-10f);
		}
	}
}