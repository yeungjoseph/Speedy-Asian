﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider volumeSlider;

	public void VolumeChanged()
	{
		AudioListener.volume = volumeSlider.value;
	}	

	public void Mute()
	{
		AudioListener.pause = !AudioListener.pause;
	}

	public void Back()
	{
		SceneManager.LoadScene ("MainMenu");   
	}


}
