using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

	public Slider volumeSlider;
	public AudioSource volumeAudio;

	public void VolumeChanged()
	{
		AudioListener.volume = volumeSlider.value;
	}	

	public void Mute()
	{
		AudioListener.pause = !AudioListener.pause;
	}
}
