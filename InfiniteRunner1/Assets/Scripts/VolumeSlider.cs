using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

	private Slider volumeSlider;

    public void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("SliderVolumeLevel", 1f);
    }

    public void Update()
	{
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("SliderVolumeLevel", volumeSlider.value);
	}	
}
