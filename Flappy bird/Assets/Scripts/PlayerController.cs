using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float forcePower;
    public bool isGameActive = true;
    void Start()
    {
        Physics.gravity = new Vector3(0f, -6f, 0f);
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive)
        {
            Debug.Log("afa");
            playerRb.AddForce(Vector3.up * forcePower, ForceMode.Impulse);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isGameActive = false;
    }
}
