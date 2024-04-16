using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainController : MonoBehaviour
{
    [SerializeField] private Text maxScoreTextMain;

    private MainManager mainManager;
    void Start()
    {
        mainManager =GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    private void Update()
    {
        if (!mainManager.m_GameOver)
        {
            string path = Application.persistentDataPath + "/" + DataSaver.Instance.userName + ".json";


            if (System.IO.File.Exists(path))
            {
                maxScoreTextMain.text = "Best score " + DataSaver.Instance.userName + ": " + DataSaver.Instance.GiveScore(path);
            }
            else
            {
                maxScoreTextMain.text = "Best score " + DataSaver.Instance.userName + ": 0";
            }
        }

    }
}
