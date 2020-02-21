using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderCtrl : MonoBehaviour
{
    public float left, right;
    public GameObject player;
    private Transform tmp;
    private Transform OldTmp;
    void FixedUpdate()
    {
        if(player.transform.position.x <= left)
        {
            Transform tmp = new GameObject().transform;
            tmp.position = new Vector3(left,player.transform.position.y,-0.3f);  
            GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = tmp;
            StartCoroutine("deleteTmp",tmp);
        }
        else if(player.transform.position.x >= right)
        {
            Transform tmp = new GameObject().transform;
            tmp.position = new Vector3(right,player.transform.position.y,-0.3f);  
            GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = tmp;
            StartCoroutine("deleteTmp",tmp);
        }
        else if(GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow != player.transform)
        {
            GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Follow = player.transform;
        }
    }
    IEnumerator deleteTmp(Transform tmp)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(tmp.gameObject);
    }
}
