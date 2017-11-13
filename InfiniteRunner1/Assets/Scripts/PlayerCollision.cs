using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script handles all instances of player collisions such
 as collectable pickups and death conditions. It utilizes the
 score script to update the score upon picking up a collectable.
*/
public class PlayerCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }

        else if (other.gameObject.CompareTag("Gem"))
        {
            IncreaseScoreBy(50f);
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
