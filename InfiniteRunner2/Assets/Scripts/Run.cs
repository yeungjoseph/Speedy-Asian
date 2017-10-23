using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {
    private Rigidbody thisrigid;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        thisrigid = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        thisrigid.velocity = new Vector3(0, thisrigid.velocity.y, speed);
	}
}
