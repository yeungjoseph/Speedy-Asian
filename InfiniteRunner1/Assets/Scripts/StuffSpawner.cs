using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {
    public Transform obstaclePrefab;
    private float MIN_X_BOUND = -2.35f;
    private float MAX_X_BOUND = 2.35f;

	// Use this for initialization
	void Start () {
        SpawnObstacles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnObstacles()
    {
        //Partition the path (z=7.6 each) and spawn obstacles in each partition
        float start_z = getPathCount() * 76f;
        for (int groundCount = 0; groundCount < 10; groundCount++)
        {
            float x_size = obstaclePrefab.GetComponent<Renderer>().bounds.size.x;
            float y_size = obstaclePrefab.GetComponent<Renderer>().bounds.size.y;
            SpawnObstacle(x_size, y_size, start_z, start_z + 7.6f);
            start_z += 7.6f;
        }
    }

    /**
     * Randomly decides whether to instantiate an obstacle or not at a random position
     * between z_min z_max
     */
    private void SpawnObstacle(float x_size, float y_size, float z_min, float z_max)
    {
        if (Random.Range(0,10) < 10) 
        {
            //Spawn obstacle
            float fence_size = 0.3f;
            float min_x = MIN_X_BOUND + x_size / 2 + fence_size;
            float max_x = MAX_X_BOUND - x_size / 2 - fence_size;
  
            Transform obstacle = Instantiate(obstaclePrefab, new Vector3(
                Random.Range(min_x,max_x),y_size/2,Random.Range(z_min,z_max)), obstaclePrefab.rotation);
            obstacle.name = "obstacle";
            obstacle.gameObject.AddComponent<TimeToDestroy>();
        }
    }

    private int getPathCount()
    {
        GameObject player = GameObject.Find("Player");
        Score score_script = player.GetComponent<Score>();
        return score_script.numPaths;
    }
}

//4.7,3.8,7.6