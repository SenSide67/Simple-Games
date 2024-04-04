using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI gameOverText;
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
        }
    }
}
