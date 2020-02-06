using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnFirstStartup : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        try
        {
            PlayerPrefs.GetInt("death");
            PlayerPrefs.GetInt("killed");
            PlayerPrefs.GetInt("hpGain");
            PlayerPrefs.GetInt("hpLoss");
        }
        catch (System.Exception)
        {
            PlayerPrefs.SetInt("death", 0);
            PlayerPrefs.SetInt("killed", 0);
            PlayerPrefs.SetInt("hpGain", 0);
            PlayerPrefs.SetInt("hpLoss", 0);            
            throw;
        }
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
