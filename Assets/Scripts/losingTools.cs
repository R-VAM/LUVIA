using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class losingTools : MonoBehaviour
{
    public Transform summonPos;


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = summonPos.position;
    }
}
