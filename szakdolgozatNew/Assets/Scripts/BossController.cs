using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject Obstacle, ToNextMap;
    public float FixXpos;
    public Animator SlimeAnim;
    private System.Random rng;
    private GameObject CurrentObstacle;
    void Start()
    {
        transform.position = new Vector3(FixXpos,transform.position.y,transform.position.z);
        rng = new System.Random();
        StartCoroutine("spawnObstacle");
    }
    void FixedUpdate()
    {
        int hp = gameObject.GetComponent<EnemyController>().currentHP;
        if (hp == 1) StartCoroutine("Death");
        if(ToNextMap.GetComponent<BoxCollider2D>().enabled)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(CurrentObstacle);
        }
    }
    IEnumerator spawnObstacle()
    {
        yield return new WaitForSeconds(float.Parse(rng.Next(3,6).ToString()));
        CurrentObstacle = Instantiate(Obstacle,new Vector3(transform.position.x,transform.position.y+1.5f,0f),Quaternion.identity);
        CurrentObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(rng.Next(1, 6),rng.Next(5, 8));
        StartCoroutine("Spawn");
    }
    IEnumerator bossDeath()
    {
        ToNextMap.GetComponent<BoxCollider2D>().enabled = true;
        ToNextMap.GetComponentInChildren<SpriteRenderer>().enabled = true;
        SlimeAnim.SetTrigger("death");
        yield return new WaitForSeconds(1.2f);
        gameObject.GetComponent<EnemyController>().death();
        Destroy(gameObject);
    }
}