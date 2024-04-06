using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacleSpawnPrefab = new GameObject[7];
    private Vector3 spawnPosition = new Vector3(10, -0.5996328f, 0.020725f);
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    
        InvokeRepeating("SpawnObstacle", 1.5f, 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void SpawnObstacle()
    {
      if(playerController.isGameActive)
            Instantiate(obstacleSpawnPrefab[Random.Range(0, 4)], spawnPosition, Quaternion.Euler(0, 0, 0));
    }
}
