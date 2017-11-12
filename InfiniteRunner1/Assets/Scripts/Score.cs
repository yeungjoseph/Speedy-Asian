using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int numPaths = 0;
    public float score = 0f;
    [SerializeField]
    Text score_text;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
    }

    private void UpdateScore()
    {
        score += 10f * Time.deltaTime;
        score_text.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }
}
