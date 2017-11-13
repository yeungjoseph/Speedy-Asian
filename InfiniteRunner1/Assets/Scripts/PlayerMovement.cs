using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            // Stick player on the floor a lil bit
            verticalVelocity = -0.5f;

            float jump = Input.GetAxisRaw("Vertical");
            if (jump == 1 && Time.time > canJump)
            {
                source.PlayOneShot(jumpsound, 1f);
                verticalVelocity = jumpForce;
                anim.Play("Jumping");

                // Delay for jump
                canJump = Time.time + .9f; // Delay for jump
            }
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

}
