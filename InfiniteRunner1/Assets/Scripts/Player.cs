using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private CharacterController controller;

    //Movement
    [SerializeField]
    private int speed;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    //Animator for jump
    private Animator anim;


	void Start () {
        anim = GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
	}

    private void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Left & Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * (0.5f*speed);
        // Up & Down
        moveVector.y = verticalVelocity;
        // Forward & Back
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    /*
	void FixedUpdate ()
    { 
        //Jump on LMB
		if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0f, 6f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
        }
        rb.velocity = new Vector3(0f, rb.velocity.y, speed);
  
	}*/


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
