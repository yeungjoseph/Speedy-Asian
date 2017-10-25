using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour {
    public Transform wavePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Transform wave = Instantiate(wavePrefab, new Vector3(transform.parent.position.x, transform.parent.position.y, 
            transform.parent.position.z + 224f), wavePrefab.rotation);
        wave.name = "wave";

        transform.parent.gameObject.AddComponent<TimeToDestroy>();
    }
}
