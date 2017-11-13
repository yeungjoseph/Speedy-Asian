using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script spawns all obstacles and collectables.
*/
public class StuffSpawner : MonoBehaviour {
    public Transform cowPrefab;
    public Transform cratePrefab;
    public Transform gemPrefab;
    private float MIN_X_BOUND = -2.35f;
    private float MAX_X_BOUND = 2.35f;
    private float fence_size = 0.3f;

    void Start () {
        SpawnObstacles();
	}

    //Partition the path (z=7.6 each) and spawn obstacles in each of the 10 sub-paths
    private void SpawnObstacles()
    {
        float start_z = getPathCount() * 76f;
        for (int groundCount = 0; groundCount < 10; groundCount++)
        {
            float x_size = cowPrefab.GetComponent<Renderer>().bounds.size.x;
            SpawnCow(x_size, start_z, start_z + 7.6f);

            x_size = cratePrefab.GetComponent<Renderer>().bounds.size.x;
            float y_size = cratePrefab.GetComponent<Renderer>().bounds.size.y;
            SpawnCrate(x_size, y_size, start_z, start_z + 7.6f);

            start_z += 7.6f;
        }
    }

    //Spawns a cow obstacle in a random but valid position
    private void SpawnCow(float x_size, float z_min, float z_max)
    {
        //Boundaries for the cow to spawn within the path
        float min_x = MIN_X_BOUND + x_size / 2 + fence_size;
        float max_x = MAX_X_BOUND - x_size / 2 - fence_size;
        Vector3 spawnPos = new Vector3(Random.Range(min_x, max_x), 0f, Random.Range(z_min, z_max));

        //Only spawn if it does not overlap with another obstacle
        if (IsSpawnAvailable(spawnPos, 0.1f) && Random.Range(0,10) < 10) 
        {
            float flip_rotation = (Random.Range(0, 10) < 5) ? 180f : 0f; //Randomize facing right or left
            Vector3 new_rotation = cowPrefab.rotation.eulerAngles;
            new_rotation = new Vector3(new_rotation.x, new_rotation.y + flip_rotation, new_rotation.z);

            Transform cow = Instantiate(cowPrefab, spawnPos, Quaternion.Euler(new_rotation)); 
            cow.name = "cow";
            cow.gameObject.AddComponent<TimeToDestroy>();
            SpawnGem(spawnPos, 2.3f);
        }
    }

    //Spawns a crate obstacle in a random but valid position
    private void SpawnCrate(float x_size, float y_size, float z_min, float z_max)
    {
        float min_x = MIN_X_BOUND + x_size / 2 + fence_size;
        float max_x = MAX_X_BOUND - x_size / 2 - fence_size;
        Vector3 spawnPos = new Vector3(Random.Range(min_x, max_x), y_size / 2f, Random.Range(z_min, z_max));

        if (IsSpawnAvailable(spawnPos, 0.4f) && Random.Range(0,10) < 10)
        {
            Transform crate = Instantiate(cratePrefab, spawnPos, cratePrefab.rotation);
            crate.name = "crate";
            crate.gameObject.AddComponent<TimeToDestroy>();
            SpawnGem(spawnPos, 1.5f);
        }
    }

    //Spawns a gem y_incr Unity units above a specified position
    private void SpawnGem(Vector3 spawnPos, float y_incr)
    {
        spawnPos.y += y_incr;
        Transform gem = Instantiate(gemPrefab, spawnPos, gemPrefab.rotation);
        gem.name = "gem";
        //Garbage collection for this object is built into the object already
    }

    //Checks if an obstacle is overlapping with any other obstacles
    private bool IsSpawnAvailable(Vector3 spawnPosition, float precision)
    {
        if (Physics.OverlapSphere(spawnPosition, precision).Length > 1) //Touching more than just ground 
        {
            return false;
        }
        return true;
    }

    //Helper function for determining where to spawn the next path
    private int getPathCount()
    {
        GameObject player = GameObject.Find("Player");
        Score score_script = player.GetComponent<Score>();
        return score_script.numPaths;
    }
}

//4.7,3.8,7.6 are dimensions of a single ground path