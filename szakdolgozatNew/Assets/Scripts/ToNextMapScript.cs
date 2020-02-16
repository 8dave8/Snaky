using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextMapScript : MonoBehaviour
{
    public GameObject panel;
    public bool RequireKey = false;
    public bool HasKey = false;
    public string Scene;
    public int currentmap;
    void Awake()
    {
        panel.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (RequireKey && HasKey) 
            {
                col.gameObject.GetComponent<PickupController>().saveCoins();
                StartCoroutine("Loadscene");
            }
            else if (!RequireKey) 
            {
                col.gameObject.GetComponent<PickupController>().saveCoins();
                StartCoroutine("Loadscene");
            }
        }
    }
    IEnumerator Loadscene()
    {
        panel.GetComponent<Animator>().SetTrigger("off");
        if (PlayerPrefs.GetInt("Biggestmap") <= currentmap)
        PlayerPrefs.SetInt("Biggestmap", currentmap);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene);
    }
}
