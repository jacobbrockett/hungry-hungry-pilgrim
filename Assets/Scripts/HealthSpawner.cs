using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{

    [SerializeField] GameObject healthPrefab;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] float SpawnInterval = 3f;


    void Start()
    {
        SpawnHealthObjects();
    }

    
    void SpawnHealth()
    {
        float rand_x = Random.Range(-14f, 14f);

        Vector3 spawnPos = new Vector3(rand_x, 14f, 0);

        GameObject newObject = Instantiate(healthPrefab, spawnPos, Quaternion.identity);

        Health newObstacle = newObject.GetComponent<Health>();

        if(newObstacle != null)
        {
            newObstacle.SetPlayerInputHandler(playerInputHandler);
        }
    }

    void SpawnHealthObjects()
    {
        StartCoroutine(SpawnHealthRoutine());

        IEnumerator SpawnHealthRoutine()
        {
            while(true)
            {
                SpawnHealth();
                yield return new WaitForSeconds(SpawnInterval);
            }
            
        }
    }
}
