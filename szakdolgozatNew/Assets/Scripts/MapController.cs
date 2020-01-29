using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int level;
    public GameObject[] maps;
    void Start()
    {
        for (int i = 0; i <= 5; i++)
        {
            if(PlayerPrefs.GetInt("Biggestmap") == i+1+level)
            {
                maps[i].SetActive(true);
            } 
        }
    }
}
