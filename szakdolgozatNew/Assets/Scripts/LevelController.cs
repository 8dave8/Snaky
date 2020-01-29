using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject level1, level2;
    void Start()
    {
        if(PlayerPrefs.GetInt("Biggestmap") >= 6) level2.SetActive(true);
    }
}
