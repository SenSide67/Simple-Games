using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject restartButton;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGameActive)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.SetActive(true);
        }
        scoreText.text = "Score: " + playerController.score;
        recordText.text = "Your record: " + PlayerPrefs.GetInt("Score");
    }
}
