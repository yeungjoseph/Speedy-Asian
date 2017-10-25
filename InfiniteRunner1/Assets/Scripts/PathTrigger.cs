using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTrigger : MonoBehaviour {
    public Transform pathPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Create a new road at the position the last road began + length of a road
        Instantiate(pathPrefab, new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y,
            transform.parent.parent.position.z + 76f), pathPrefab.rotation);
        transform.parent.parent.gameObject.AddComponent<TimeToDestroy>();
    }
}
