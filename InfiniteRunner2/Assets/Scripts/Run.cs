using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {
    private Rigidbody thisrigid;
    //private float HALF_ROAD_WIDTH = 23f; //Bounds for player movement
    public float z_speed = 5f;
    public float x_speed = 500f;

	// Use this for initialization
	void Start () {

        thisrigid = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.anyKey)
        {
            thisrigid.velocity = new Vector3(Input.GetAxis("Horizontal") * x_speed, thisrigid.velocity.y, z_speed);
        }

        else
        {
            thisrigid.velocity = new Vector3(0, thisrigid.velocity.y, z_speed);
        }
        //thisrigid.velocity = new Vector3(Input.acceleration.x, thisrigid.velocity.y, z_speed);

    }
}
