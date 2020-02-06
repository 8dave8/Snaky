using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefsLoad : MonoBehaviour
{
    public Text kill, death, hpgain, hploss, coins;
    void Start()
    {
        kill.text = "Killed: "+PlayerPrefs.GetInt("killed").ToString();
        death.text = "Died: "+PlayerPrefs.GetInt("death").ToString();
        hpgain.text = "Hp gain: "+PlayerPrefs.GetInt("hpGain").ToString();
        hploss.text = "Hp loss: "+PlayerPrefs.GetInt("hpLoss").ToString();
        coins.text = "Coins: "+PlayerPrefs.GetInt("coins").ToString();
    }
}
