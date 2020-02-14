﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public Text coinText;
    private bool colliding;
    void Start()
    {
        colliding = false;
        int coins = PlayerPrefs.GetInt("coins");
        if (coins <= 9) coinText.text = "00"+coins;
        else if (coins <= 99) coinText.text = "0"+coins;
        else coinText.text = coins+"";
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Coin") && gameObject.layer == 0 && colliding == false)
        {  
            Destroy(col.transform.parent.gameObject);
            colliding = true;
            StartCoroutine("wait");
            int coins = PlayerPrefs.GetInt("coins") + 1;
            PlayerPrefs.SetInt("coins", coins);
            if (coins <= 9) coinText.text = "00"+coins;
            else if (coins <= 99)  coinText.text = "0"+coins;
            else coinText.text = coins+"";
        }
        if(col.gameObject.CompareTag("Hearth") && gameObject.layer == 0 && colliding == false && GetComponent<HealthConroller>().health != 3)
        {
            Destroy(col.gameObject);
            colliding = true;
            StartCoroutine("wait");
            GetComponent<HealthConroller>().addHealth();
        }
        if(col.gameObject.CompareTag("Pebble") && gameObject.layer == 0 && colliding == false && GetComponentInChildren<attackController>().pebbles !=3)
        {
            Destroy(col.gameObject);
            colliding = true;
            StartCoroutine("wait");
            GetComponentInChildren<attackController>().pickupPebble();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.01f);
        colliding = false;
    }

}
