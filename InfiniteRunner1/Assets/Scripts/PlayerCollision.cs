using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }

        else if (other.gameObject.CompareTag("Gem"))
        {
            IncreaseScoreBy(100f);
            Destroy(other.gameObject);
        }
    }

    private void IncreaseScoreBy(float points)
    {
        GameObject player = GameObject.Find("Player");
        Score score_script = player.GetComponent<Score>();
        score_script.score += points;
    }

    private void GameOver()
    {
        Debug.Log("Game is over");
    }
}
