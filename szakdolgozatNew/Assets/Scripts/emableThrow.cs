using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emableThrow : MonoBehaviour
{
    public GameObject[] toEnable;
    void Start()
    {
        if(PlayerPrefs.GetInt("canThrow")==1)
        {
            for (int i = 0; i < toEnable.Length; i++)
                toEnable[i].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("canThrow")==0)
        {
            for (int i = 0; i < toEnable.Length; i++)
                toEnable[i].SetActive(false);
        }
    }
}
