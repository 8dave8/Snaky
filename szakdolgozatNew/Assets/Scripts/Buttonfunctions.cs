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
        Time.timeScale = 1;
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
    public void Stopgame()
    {
        Time.timeScale = 0;
    }
    public void Resumegame()
    {
        Time.timeScale = 1;
    }
}
