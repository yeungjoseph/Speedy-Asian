using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDimensions : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetComponent<Renderer>().bounds.size);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
