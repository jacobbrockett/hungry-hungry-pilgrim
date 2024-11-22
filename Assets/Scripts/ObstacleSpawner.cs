using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* class: ObstacleSpawner
* description: Class responsible for generating obstacle objects in random positions every 0.5 seconds
*/
public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnTimeInterval = 0.5f;

    /**
    * function: Start()
    * args: None
    * description: Begin the coroutine responsible for generating obstacles
    */
    void Start()
    {
        SpawnObstacles();
    }

    /**
    * function: SpawnObstacle()
    * args: None
    * description: Instantiates a new obstacle object above the camera view at a random x coordinate
    */
    void SpawnObstacle()
    {
        float rand_x = Random.Range(-14f, 14f);

        Vector3 spawnPos = new Vector3(rand_x, 14f, 0);

        GameObject newObject = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }

    /**
    * function: SpawnObstacles()
    * args: None
    * description: Runs the coroutine that generates an obstacle every 0.5 seconds
    */
    void SpawnObstacles()
    {
        StartCoroutine(SpawnObstaclesRoutine());

        IEnumerator SpawnObstaclesRoutine()
        {
            while(true)
            {
                SpawnObstacle();
                yield return new WaitForSeconds(spawnTimeInterval);
            }
            
        }
    }
}
