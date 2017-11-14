using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    [SerializeField]
    private Text final_score;
    private Score score_script;
    public Image backgroundImg;

    //Transition animation
    private bool isShown = false;
    private float transition = 0.0f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, .8f), transition);
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Show()
    {
        score_script = GameObject.Find("Player").GetComponent<Score>();
        final_score.text = "Score: " + Mathf.RoundToInt(score_script.score).ToString();
        gameObject.SetActive(true);
        isShown = true;
    }
}

