using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackController : MonoBehaviour
{
    public GameObject CharacterAnimator, Obstacle, Pebble1, Pebble2, Pebble3;
    public Sprite EmptyPebble, FullPebble;
    public BoxCollider2D box;
    public float attackDuration;
    public float attackStartDuration;
    private bool attacking = false;
    private int canThrow;
    public int pebbles = 3;
    void Start()
    { 
        canThrow = PlayerPrefs.GetInt("canThrow");
        Physics.IgnoreLayerCollision(11,9);
        box.enabled = false;
    }
    private void ThrowPebble()
    {
        pebbles--;
        if (pebbles == 2) Pebble3.GetComponent<Image>().sprite = EmptyPebble;
        else if (pebbles == 1) Pebble2.GetComponent<Image>().sprite = EmptyPebble;
        else if (pebbles == 0) Pebble1.GetComponent<Image>().sprite = EmptyPebble;
    }
    public void pickupPebble()
    {
        if(pebbles != 3) pebbles++;
        if(pebbles == 3) Pebble3.GetComponent<Image>().sprite = FullPebble;
        else if(pebbles == 2) Pebble2.GetComponent<Image>().sprite = FullPebble;
        else if(pebbles == 1) Pebble2.GetComponent<Image>().sprite = FullPebble;
    }
    public void EnableDamage()
    {
        if (attacking) return;
        StartCoroutine("DisableDamage");
        CharacterAnimator.GetComponent<Animator>().Play("Attack");
        CharacterAnimator.GetComponent<Animator>().SetBool("Jumping", false);
        }
    IEnumerator DisableDamage()
    {
        yield return new WaitForSeconds(attackStartDuration);
        transform.parent.gameObject.layer = 11;
        attacking = true;
        box.enabled = true;
        yield return new WaitForSeconds(attackDuration);
        transform.parent.gameObject.layer = 0;
        attacking = false;
        box.enabled = false;
    }

    public void Throw()
    {
        if(canThrow == 1 && pebbles >=1)
        {
            ThrowPebble();
            float x = 8f;
            var currentObstacle = Instantiate(Obstacle,new Vector3(transform.position.x,transform.position.y+1.5f,0),Quaternion.identity);
            if(gameObject.transform.parent.localScale.x == -5 && x == 8) x = -8f;
            else if(gameObject.transform.parent.localScale.x == 5 && x == -8) x = 8f;
            currentObstacle.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,5f),ForceMode2D.Impulse);
        }
    }
}
