using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSaver : MonoBehaviour
{
    private MainManager mainManager;
    public static DataSaver Instance { get;private set; }

    public string userName;
    public int points;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "main")
        {
            mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        }
        

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

      
    }

    private void Update()
    {
        
    }

    [Serializable]
    private class SaveData
    {
        public int score;
    }

    public void SaveScore()
    {
        SaveData score = new SaveData();
        score.score = points;

        string json = JsonUtility.ToJson(score);        

        File.WriteAllText(Application.persistentDataPath + "/" + userName + ".json", json);
    }

    public bool IsItMaxScore()
    {
        string path = Application.persistentDataPath + "/" + userName + ".json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData score = JsonUtility.FromJson<SaveData>(json);
            if (score.score <= points)
            {
                return true;
            }
            else
                return false;
        }
        return true;
    }

    public int GiveScore(string path)
    {
        string json = System.IO.File.ReadAllText(path);
        SaveData score = JsonUtility.FromJson<SaveData>(json);
        return score.score;
    }
}
