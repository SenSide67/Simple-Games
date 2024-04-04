using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacleSpawnPrefab = new GameObject[5];
    private Vector3 spawnPosition = new Vector3(10, -0.5996328f, 0.020725f);
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void SpawnObstacle()
    {
        Instantiate(obstacleSpawnPrefab[Random.Range(0, 4)], spawnPosition, Quaternion.Euler(0, 0, 0));
    }
}
