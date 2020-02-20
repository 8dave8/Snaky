using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnFirstStartup : MonoBehaviour
{
    public Text throwtext, loot;
    public Button throwBT;
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
        if(PlayerPrefs.GetInt("canThrow") == 1) disableThrowBuying();
        if(PlayerPrefs.GetInt("moreLoot") >= 1) setBoughtLoot();
    }
    private void disableThrowBuying()
    {
        throwtext.color = Color.green;
        throwBT.enabled = false;
        throwtext.text = "Megvett";
    }
    private void setBoughtLoot()
    {
        loot.text = "Megvett: "+PlayerPrefs.GetInt("moreLoot");
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
            disableThrowBuying();
        }
    }
    public void EnableMoreLoot()
    {
        if(PlayerPrefs.GetInt("coins") >= 1000 && PlayerPrefs.GetInt("moreLoot") < 5)
        {
            PlayerPrefs.SetInt("moreLoot",PlayerPrefs.GetInt("moreLoot")+1);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")-1000);
            setBoughtLoot();
        }
    }
}
