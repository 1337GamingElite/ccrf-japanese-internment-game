using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour {

	public string TriggerKey;
	public string StopKey;
	AudioSource audio;
	bool played = false;

	const float coef = 0.2f;

	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if (Time.timeScale == 0f)
			audio.Pause();
		if (Time.timeScale == 1f)
			audio.UnPause();

		if (PlayerPrefs.GetInt(TriggerKey, 0) == 1 && !audio.playOnAwake && !played)
		{
			played = true;
			audio.Play();
		}
		if (PlayerPrefs.GetInt(StopKey, 0) == 1)
		{
			audio.volume -= coef * Time.deltaTime;
			if (audio.volume == 0f)
			{
				Destroy(this.gameObject);
			}
		}

	}

}
