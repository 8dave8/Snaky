using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public bool FacingLeft;
    public float speed;
    public GameObject Projectile; 
    void Start()
    {
        if(FacingLeft) speed *= -1;
        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.5f);
        var CurrentObstacle = Instantiate(Projectile,new Vector3(transform.position.x-0.2f,transform.position.y+1.1f,0f),Quaternion.identity);
        CurrentObstacle.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed,0f),ForceMode2D.Impulse);
        StartCoroutine("Spawn");
    }
}
