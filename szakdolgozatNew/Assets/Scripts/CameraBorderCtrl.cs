using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderCtrl : MonoBehaviour
{
    public float left, right;
    public GameObject player;
    void FixedUpdate()
    {
        if(player.transform.position.x <= left)
        {
            Transform tmp = new GameObject().transform;
            tmp.position = new Vector3(left,player.transform.position.y,-0.3f);  
            GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = tmp;
        }
        else if(player.transform.position.x >= right)
        {
            Transform tmp = new GameObject().transform;
            tmp.position = new Vector3(right,player.transform.position.y,-0.3f);  
            GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = tmp;
        }
        else  GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = player.transform;
    }
}
