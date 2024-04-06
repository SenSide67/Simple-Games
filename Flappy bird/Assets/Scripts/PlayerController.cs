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
    private Animator animator;
    private AudioSource wingSound;
 
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpCooldown = GetComponent<Cooldown>();
        wingSound = GetComponent<AudioSource>();
        animator =GameObject.Find("yellowbird-downflap").GetComponent<Animator>();
        jumpCooldown.cooldownTime = 0.15f;
        Physics.gravity = new Vector3(0f, -5f, 0f);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive && jumpCooldown.canDoAction)
        {
            playerRb.AddForce(Vector3.up * forcePower, ForceMode.Impulse);
            jumpCooldown.StartTimer();
            wingSound.Play();
        }

        if (!isGameActive)
        {
            if (PlayerPrefs.GetInt("Score") < score)
            {
                SaveScore();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            isGameActive = false;
            animator.SetBool("isDead", true);
        }

        if (other.gameObject.CompareTag("obstaclePassed"))
        {
            score++;
        }

        if (other.gameObject.CompareTag("base"))
        {
            playerRb.constraints = RigidbodyConstraints.FreezePositionY;
            isGameActive = false;
            animator.SetBool("isDead", true);
        }
    }

    private void SaveScore()
    {     
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
