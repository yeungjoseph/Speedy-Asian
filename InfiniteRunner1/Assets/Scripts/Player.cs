using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody rb;

    //Running
    [SerializeField]
    private int speed;

    //Animator for jump
    private Animator anim;


	void Start () {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();

        //Set player movement speed
        rb.velocity = new Vector3(0f, 0f, speed);
	}


	void FixedUpdate ()
    { 
        //Jump on LMB
		if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0f, 6f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
        }
        rb.velocity = new Vector3(0f, rb.velocity.y, speed);
  
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game is over");
    }
}
