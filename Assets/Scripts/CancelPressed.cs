using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPressed : MonoBehaviour
{
    public Transform summonPos;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tools"))
        {
            other.gameObject.transform.position = summonPos.position;
            other.gameObject.SetActive(false);
        }
    }
}
