using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script detects when a player enters a trigger area in
 the path and appends a new path at the end of the current path
 to create an infinite road. It also works with the score script
 to keep track of the number of paths traversed.
*/
public class PathTrigger : MonoBehaviour {
    public Transform pathPrefab;

    private void OnTriggerEnter(Collider other)
    {
        //Create a new road at the position the last road began + length of a road
        Transform path = Instantiate(pathPrefab, new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y,
            transform.parent.parent.position.z + 76f), pathPrefab.rotation);
        path.name = "Path_of_10_1";

        IncrementPathCount();
        transform.parent.parent.gameObject.AddComponent<TimeToDestroy>();
    }

    private void IncrementPathCount()
    {
        GameObject player = GameObject.Find("Player");
        Score score_script = player.GetComponent<Score>();
        score_script.numPaths++;
    }
}
