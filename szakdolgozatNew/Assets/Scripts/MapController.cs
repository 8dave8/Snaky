using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int level;
    public GameObject[] maps;
    void Start()
    {
        int i = 0;
        while ( i <= PlayerPrefs.GetInt("Biggestmap")-level)
        {
            maps[i].SetActive(true);     
            i++;
        }
    }
}
