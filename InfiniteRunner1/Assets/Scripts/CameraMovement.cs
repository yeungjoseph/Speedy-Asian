using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    Transform target;

    Vector3 offset;

	void Start ()
    {
        //Find constant distance between camera and player
        offset = target.transform.position - this.transform.position;
	}
	

	void Update ()
    {
        Vector3 camera_pos = target.transform.position - offset;
        //Smoothly transition camera position
        this.transform.position = Vector3.Lerp(this.transform.position, camera_pos, 1.5f);
	}
}
