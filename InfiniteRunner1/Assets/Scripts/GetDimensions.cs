using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script is used for debugging. Use it by attaching it
 as a component to an object. It will print out the dimensions
 of the object in the debugger console as a Vector3.
*/
public class GetDimensions : MonoBehaviour {

	void Start () {
        Debug.Log(GetComponent<Renderer>().bounds.size);
	}

}
