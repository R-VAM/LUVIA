using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonPressed : MonoBehaviour
{
    public GameObject tools;
    public Transform summonPos;


    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(tools, summonPos.position, Quaternion.identity);
    }
}
