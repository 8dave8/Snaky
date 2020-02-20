using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookController : MonoBehaviour
{
    public GameObject KerdesMenu, Main;
    public int kerdesSzama;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Main.SetActive(false);
            KerdesMenu.SetActive(true);
            gameObject.GetComponent<JsonData>().readData(kerdesSzama);
        }
    }
    public void closeBookMenu ()
    {
        Main.SetActive(true);
        KerdesMenu.SetActive(false);
    }
}
