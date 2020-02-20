using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public Text coinText;
    private bool colliding;
    private int currentCoins;
    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("coins");
        colliding = false;
        coinText.text = currentCoins.ToString("000");
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Coin") && gameObject.layer == 0 && colliding == false)
        {  
            Destroy(col.transform.parent.gameObject);
            colliding = true;
            StartCoroutine("wait");
            currentCoins += 5;
            coinText.text = currentCoins.ToString("000");
        }
        if(col.gameObject.CompareTag("SilverCoin") && gameObject.layer == 0 && colliding == false)
        {  
            Destroy(col.transform.parent.gameObject);
            colliding = true;
            StartCoroutine("wait");
            currentCoins += 3;
            coinText.text = currentCoins.ToString("000");
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
            GetComponentInChildren<attackController>().pickupPebble();
            GetComponentInChildren<attackController>().pickupPebble();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.01f);
        colliding = false;
    }
    public void saveCoins()
    {
        PlayerPrefs.SetInt("coins", currentCoins);
    }
}
