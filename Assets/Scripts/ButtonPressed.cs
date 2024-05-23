using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonPressed : MonoBehaviour
{
    public GameObject tools;
    public GameObject SummonPos;
    private void OnTriggerEnter(Collider collision)
    {
        tools.transform.position = SummonPos.transform.position;
        tools.SetActive(true);
    }
}
