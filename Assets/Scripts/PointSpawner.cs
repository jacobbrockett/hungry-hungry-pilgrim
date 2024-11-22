using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* class: PointSpawner
* description: Class responsible for generating Point objects in random positions every 2 seconds
*/
public class PointSpawner : MonoBehaviour
{
    [SerializeField] GameObject pointPrefab;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] float SpawnInterval = 2f;

    /**
    * function: Start()
    * args: None
    * description: Begin the coroutine responsible for generating Points
    */
    void Start()
    {
        SpawnPoints();
    }

    /**
    * function: SpawnPoint()
    * args: None
    * description: Instantiates a new Point object above the camera view at a random x coordinate
    */
    void SpawnPoint()
    {
        float rand_x = Random.Range(-14f, 14f);

        Vector3 spawnPos = new Vector3(rand_x, 12f, 0);

        GameObject newObject = Instantiate(pointPrefab, spawnPos, Quaternion.identity);

        Point newPoint = newObject.GetComponent<Point>();

        if(newPoint != null)
        {
            newPoint.SetPlayerInputHandler(playerInputHandler);
        }
    }

    /**
    * function: SpawnPoints()
    * args: None
    * description: Runs the coroutine that generates a Point every 2 seconds
    */
    void SpawnPoints()
    {
        StartCoroutine(SpawnPointsRoutine());

        IEnumerator SpawnPointsRoutine()
        {
            while(true)
            {
                SpawnPoint();
                yield return new WaitForSeconds(SpawnInterval);
            }
            
        }
    }
}
