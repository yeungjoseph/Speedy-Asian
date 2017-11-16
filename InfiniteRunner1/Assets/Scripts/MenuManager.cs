using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text highscoreText;
    private void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    public void ToGame()
	{
        SceneManager.LoadScene("InfiniteRun");
	}

	public void ToOptions()
	{
		SceneManager.LoadScene ("OptionsUI");
	}
		
}
