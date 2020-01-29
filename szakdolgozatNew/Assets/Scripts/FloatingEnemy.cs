using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    public SpriteRenderer skin;
    public Sprite goingUp;
    public Sprite goingDown;
    public float y1,y2;
    private bool isGoingUp;
    private Vector3 v1, v2;
    void Start()
    {
        isGoingUp = true;
        v1 = new Vector3(transform.position.x,y1,transform.position.z);
        v2 = new Vector3(transform.position.x,y2,transform.position.z);
    }
    void Update()
    {
        if (transform.position.y == y1) isGoingUp = false;
        else if (transform.position.y == y2) isGoingUp = true;

        if(isGoingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position,v1, 0.1f);
            skin.sprite = goingUp;

        }
        else if (!isGoingUp)
        {
            skin.sprite = goingDown;
            transform.position = Vector3.MoveTowards(transform.position,v2, 0.1f);
        }
    }
}
