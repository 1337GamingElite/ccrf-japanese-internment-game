using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideoOnCavas : MonoBehaviour {

	public RawImage image;
	public VideoPlayer player;
	RenderTexture text;

	// Use this for initialization
	void Start () {
		text = new RenderTexture((int)player.clip.width, (int)player.clip.height, 0);

		player.targetTexture = text;
		image.texture = text;

	}

	void Update()
	{
		if ((long)player.frame == (long)player.frameCount - (long)1f && player.isPlaying)
		{
			SceneManager.LoadScene (0);
		}
	}

}
