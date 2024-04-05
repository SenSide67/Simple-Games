using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float forcePower;
    public bool isGameActive = true;
    private Cooldown jumpCooldown;
    public int score;
    
    void Start()
    {
        Physics.gravity = new Vector3(0f, -5f, 0f);
        playerRb = GetComponent<Rigidbody>();
        jumpCooldown = GetComponent<Cooldown>();
        jumpCooldown.cooldownTime = 0.15f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive && jumpCooldown.canDoAction)
        {
            Debug.Log("afa");
            playerRb.AddForce(Vector3.up * forcePower, ForceMode.Impulse);
            jumpCooldown.StartTimer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            isGameActive = false;
        }

        if (other.gameObject.CompareTag("obstaclePassed"))
        {
            score++;
        }

        if (other.gameObject.CompareTag("base"))
        {
            playerRb.constraints = RigidbodyConstraints.FreezePositionY;
            isGameActive = false;
        }
    }
}
