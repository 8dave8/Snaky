using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnFirstStartup : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("started") != 1)
        {
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("started", 1);
            SceneManager.LoadScene("FirstLoad");
        }else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
