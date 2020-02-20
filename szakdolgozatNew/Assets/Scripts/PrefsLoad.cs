using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefsLoad : MonoBehaviour
{
    public Text kill, death, hpgain, hploss, coins, shopCoins;
    void Start()
    {
        kill.text = "Ölve: "+PlayerPrefs.GetInt("killed").ToString();
        death.text = "Halál: "+PlayerPrefs.GetInt("death").ToString();
        hpgain.text = "Élet +: "+PlayerPrefs.GetInt("hpGain").ToString();
        hploss.text = "Élet -: "+PlayerPrefs.GetInt("hpLoss").ToString();
        coins.text = "Érmék: "+PlayerPrefs.GetInt("coins").ToString();
        shopCoins.text = PlayerPrefs.GetInt("coins")+" érméd van";
    }
}
