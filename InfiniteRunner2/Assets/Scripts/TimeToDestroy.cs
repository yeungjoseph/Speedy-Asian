using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour {
    public float destroyTime = 30f;
    private float currentTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        currentTime += Time.deltaTime;

        //Destroy object 30 seconds after creating it
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }

	}
}
