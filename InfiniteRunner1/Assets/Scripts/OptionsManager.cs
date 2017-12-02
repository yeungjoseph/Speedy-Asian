using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public void Mute()
	{
		AudioListener.pause = !AudioListener.pause;
	}

	public void Back()
	{
		SceneManager.LoadScene ("MainMenu");   
	}


}
