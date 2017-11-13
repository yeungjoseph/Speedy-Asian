using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 This script handles all instances of player collisions such
 as collectable pickups and death conditions. It utilizes the
 score script to update the score upon picking up a collectable.
*/
public class PlayerCollision : MonoBehaviour
{
    //Audio variables
    public AudioClip cowsound;
    public AudioClip cratesound;
    public AudioClip gemsound;
    private AudioSource source;

    //Score variables
    private Score score_script;
    private GameObject player;
    public DeathMenu death_menu;
    public Text score;


    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        score_script = player.GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
            source.PlayOneShot(cratesound, 0.25f);
        }
        else if (other.gameObject.CompareTag("crate"))
        {
            GameOver();
            source.PlayOneShot(cratesound, 0.25f);
        }
        else if (other.gameObject.CompareTag("Cow"))
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
        score_script.score += points;
    }

    private void GameOver()
    {
        //Show score
        death_menu.Show();

        //Disable player
        player.GetComponent<Collider>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        score_script.enabled = false;
    }
}

