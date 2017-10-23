using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour {
    public Transform roadPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Create a new road at the position of the last road + length of a road
        Instantiate(roadPrefab, new Vector3(0, 0, transform.parent.position.z + 154.71f), roadPrefab.rotation);
        transform.parent.gameObject.AddComponent<TimeToDestroy>();
    }
}
