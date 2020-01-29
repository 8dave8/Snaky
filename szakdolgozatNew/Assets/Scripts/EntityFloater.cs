using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityFloater : MonoBehaviour
{
    public float speed;
    public float floatDistance;
    private int direction;
    private Vector3 startPosition; 
    void Start()
    {
        floatDistance = 0.2f;
        direction = 1;
        startPosition = transform.position;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (transform.position.y >= startPosition.y + floatDistance) direction = -1;
	    if (transform.position.y < startPosition.y) direction = 1;
	    transform.position = new Vector3(
            transform.position.x,
            transform.position.y + Time.deltaTime*direction*speed,
            transform.position.z);
    }
}
