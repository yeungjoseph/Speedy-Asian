using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour {

	void Start () {
        AudioListener.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 1f);
	}
}
