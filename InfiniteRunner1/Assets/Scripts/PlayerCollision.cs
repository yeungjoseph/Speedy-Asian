using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script handles all instances of player collisions such
 as collectable pickups and death conditions. It utilizes the
 score script to update the score upon picking up a collectable.
*/
public class PlayerCollision : MonoBehaviour {
    public AudioClip cowsound;
    public AudioClip cratesound;
    public AudioClip gemsound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
            source.PlayOneShot(cratesound, 0.25f);
        }
            if (other.gameObject.CompareTag("crate"))
        {
            GameOver();
            source.PlayOneShot(cratesound, 0.25f);
        }
        if (other.gameObject.CompareTag("Cow"))
        {
            GameOver();
            source.PlayOneShot(cowsound, 1f);
        }

        else if (other.gameObject.CompareTag("Gem"))
        {
            IncreaseScoreBy(50f);
            Destroy(other.gameObject);
            source.PlayOneShot(gemsound, 1f);
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
