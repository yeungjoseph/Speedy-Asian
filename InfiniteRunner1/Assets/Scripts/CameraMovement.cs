using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    private Vector3 moveVector;

    //Starting animation
    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	void Start ()
    {
        //Find constant distance between camera and player
        offset = this.transform.position - target.transform.position;
	}
	

	void Update ()
    {
        moveVector = target.transform.position + offset;
        // X
        moveVector.x = 0;
        // Y
        moveVector.y = Mathf.Clamp(moveVector.y, 2f, 5f);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            // When 1 second passes, transition = 0.5, 2 seconds -> transition = 1 (fully moved)
            transition += Time.deltaTime * 1 / animationDuration;
        }
	}
}
