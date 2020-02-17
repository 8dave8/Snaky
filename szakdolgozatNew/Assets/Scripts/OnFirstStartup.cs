using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnFirstStartup : MonoBehaviour
{
    void Start()
    {
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
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("started", 1);
            PlayerPrefs.SetInt("canThrow", 0);
            PlayerPrefs.SetInt("moreLoot", 0);
            throw;
        }
        //PlayerPrefs.SetInt("coins",999);
        //PlayerPrefs.SetInt("moreLoot", 15);      
    }
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void EnableThrowing()
    {
        if(PlayerPrefs.GetInt("coins") >= 300)
        {
            PlayerPrefs.SetInt("canThrow",1);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")-300);
            Debug.Log("EnaThrow");
        }
    }
    public void EnableMoreLoot()
    {
        if(PlayerPrefs.GetInt("coins") >= 1000)
        {
            Debug.Log("EnaLoot");
            PlayerPrefs.SetInt("moreLoot",PlayerPrefs.GetInt("moreLoot")+1);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")-1000);
        }
    }
}
