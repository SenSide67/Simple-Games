using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text maxScoreText;
   
    public void QuitButton()
    {
#if UNITY_EDITOR
         EditorApplication.ExitPlaymode();
#else
         Application.Quit();
#endif
    }

    private void Start()
    { 
    }

    

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveUserInput(string name)
    {
        DataSaver.Instance.userName = name;

        string path = Application.persistentDataPath + "/" + name + ".json";


        if (System.IO.File.Exists(path))
        {           
            maxScoreText.text = "Best score " + name + ": " + DataSaver.Instance.GiveScore(path);
        }
        else
        {
            maxScoreText.text = "Best score " + name + ": 0";
        }
    }

       
}
