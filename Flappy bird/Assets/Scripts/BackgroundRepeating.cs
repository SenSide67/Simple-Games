using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeating : MonoBehaviour
{
    private Vector3 startPosition;
    private float speed = 3.5f;
    private float sizeOfOneSlide = 17.78f;

    private PlayerController playerController;

    void Start()
    {
        startPosition = transform.position;

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= -sizeOfOneSlide) transform.position = startPosition;
        }     
    }
}
