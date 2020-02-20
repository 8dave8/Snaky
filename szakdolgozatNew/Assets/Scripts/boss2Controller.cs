using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Controller : MonoBehaviour
{
    private bool isAttacking = false;
    public BoxCollider2D ColAttack;
    public BoxCollider2D AttackTrigger;
    public Animator Anim;
    void Start()
    {
        ColAttack.GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("trigger");
        if(col.gameObject.CompareTag("Player") && 
        gameObject.GetComponentInChildren<Transform>().gameObject.tag == "Respawn")
        {
            if(isAttacking == true) return;
            else isAttacking = true;
            StartCoroutine("attack");
        }
    }
    IEnumerator attack()
    {
        Anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.15f);
        ColAttack.enabled = true;
        yield return new WaitForSeconds(0.14f);
        ColAttack.enabled = false;
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }
}
