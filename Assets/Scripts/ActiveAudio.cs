using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAudio : MonoBehaviour
{

	public Button audioButton;
	public AudioSource audio;

	void Start()
	{
		Button btn = audioButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		audio.Play();
	}

	public void tocaAudio()
    {
		audio.Play();
	}
}
