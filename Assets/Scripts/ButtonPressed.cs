using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonPressed : MonoBehaviour
{
    public GameObject tools;

    private void OnTriggerEnter(Collider collision)
    {
        tools.SetActive(true);
    }
}
