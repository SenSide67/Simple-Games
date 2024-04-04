using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private PlayerController playerController;

     void Start()
     {
       playerController = GameObject.Find("Player").GetComponent<PlayerController>();
     }

    void Update()
    {
        if(playerController.isGameActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }             
    }
}
