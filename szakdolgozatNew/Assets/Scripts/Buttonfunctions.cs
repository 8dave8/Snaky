using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttonfunctions : MonoBehaviour
{
    public Text CurrentMap;
    void Start()
    {
        CurrentMap.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
