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
    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void loadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void stopGame()
    {
        Time.timeScale = 0;
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
    }
}
