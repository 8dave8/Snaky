using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    public Animator Menu;
    private void Start()
    {
        Menu.GetComponent<Animator>();
    }
    public void MenuToSettings()
    {
        Menu.SetTrigger("MainToSettings");
    }
    public void SettingsToMenu()
    {
        Menu.SetTrigger("SettingsToMain");
    }
    public void MenuToStats()
    {
        Menu.SetTrigger("MainToStats");
    }
    public void StatsToMenu()
    {
        Menu.SetTrigger("StatsToMain");
    }
    public void MenuToLevels()
    {
        Menu.SetTrigger("MainToLevels");
    }
    public void LevelsToMenu()
    {
        Menu.SetTrigger("LevelsToMain");
    }
    public void LevelsToLevel1()
    {
        Menu.SetTrigger("LevelsToLevel1");
    }
    public void LevelsToLevel2()
    {
        Menu.SetTrigger("LevelsToLevel2");
    }
    public void Level1ToLevels()
    {
        Menu.SetTrigger("Level1ToLevels");
    }
    public void Level2ToLevels()
    {
        Menu.SetTrigger("Level2ToLevels");
    }
}
