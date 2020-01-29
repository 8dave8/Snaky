using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject Obstacle, ToNextMap;
    public Animator SlimeAnim;
    private System.Random rng;
    void Start()
    {
        rng = new System.Random();
        StartCoroutine("Spawn");
    }
    void FixedUpdate()
    {
        int hp = gameObject.GetComponent<EnemyController>().currentHP;
        if (hp == 1) StartCoroutine("Death");
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(float.Parse(rng.Next(3,6).ToString()));
        GameObject obj = Instantiate(Obstacle,new Vector3(transform.position.x,transform.position.y+1.5f,0f),Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(rng.Next(1, 6),rng.Next(5, 8));
        StartCoroutine("Spawn");
    }
    IEnumerator Death()
    {
        ToNextMap.SetActive(true);
        SlimeAnim.SetTrigger("death");
        yield return new WaitForSeconds(1.2f);
        gameObject.GetComponent<EnemyController>().death();
    }
}
