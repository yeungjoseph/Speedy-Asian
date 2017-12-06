using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script is responsible for all of the character's movements
 and animations. A non-physics conforming character controller
 is used to move the character.
*/
public class PlayerMovement : MonoBehaviour {
    private CharacterController controller;

    // Movement
    [SerializeField]
    private int speed;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 18.0f;
    [SerializeField]
    private float jumpForce = 6.0f;
    private float canJump = 0f;

    // Animator for jump
    private Animator anim;

    // Audio for player
    public AudioClip jumpsound;
    private AudioSource source;

	void Start () {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
	}

    private void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            // Stick player on the floor a little bit
            verticalVelocity = -0.5f;

            bool jump = Input.GetMouseButtonDown(0) && (Input.mousePosition.y < 7 * Screen.height / 8);
            if (jump && Time.time > canJump)
            {
                source.PlayOneShot(jumpsound, 1f);
                verticalVelocity = jumpForce;
                anim.Play("Jumping");

                // Delay for next jump
                canJump = Time.time + .9f;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Left & Right
        moveVector.x = Input.acceleration.x * (0.75f*speed);
        // Up & Down
        moveVector.y = verticalVelocity;
        // Forward & Back
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

}
