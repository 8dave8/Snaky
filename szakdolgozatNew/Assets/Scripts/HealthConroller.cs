using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthConroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite FullHearth;
    public Sprite EmptyHearth;
    public GameObject hearth1;
    public GameObject hearth2;
    public GameObject hearth3;
    public int health;
    private System.Random rng = new System.Random();
    private bool takingDamage = false;
    void Start()
    {
        Physics.IgnoreLayerCollision(11,9);
        Physics.IgnoreLayerCollision(14,0);
        health = 3;
    }
    public void takeDamage()
    {
        PlayerPrefs.SetInt("hpLoss", PlayerPrefs.GetInt("hpLoss")+1);
        health--;
        if (health == 2) hearth3.GetComponent<Image>().sprite = EmptyHearth;
        else if (health == 1) hearth2.GetComponent<Image>().sprite = EmptyHearth;
        else if (health == 0) hearth1.GetComponent<Image>().sprite = EmptyHearth;
        if (health <= 0) Death();
    }
    public void addHealth()
    {
        if(health <= 0) Death();
        if(health != 3) health++;
        PlayerPrefs.SetInt("hpGain", PlayerPrefs.GetInt("hpGain")+1);
        if(health == 3) hearth3.GetComponent<Image>().sprite = FullHearth;
        else if(health == 2) hearth2.GetComponent<Image>().sprite = FullHearth;
    }
    void OnTriggerStay2D(Collider2D col)
    {   
        if (col.gameObject.tag == "Enemy" && gameObject.layer == 0)
            gotHit();      
    }
    IEnumerator wait()
    {
        takingDamage = true;
        takeDamage();
        yield return new WaitForSeconds(1.2f);
        takingDamage = false;
    }
    private void gotHit()
    {
        if(takingDamage) return;
        //knokback
        int i = 0;
        if (rng.Next(0,2) == 0) i = 1;
        else i = -1; 
        rb.AddForce(new Vector2(rng.Next(200,300)*i,rng.Next(300,450)));
        //dmg
        StartCoroutine("wait");
    }
    private void Death()
    {
        PlayerPrefs.SetInt("death",PlayerPrefs.GetInt("death")+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}