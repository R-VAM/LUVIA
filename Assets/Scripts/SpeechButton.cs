using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechButton : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        btn.onClick.Invoke();
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void OnTriggerEnter(Collider other)
    {
        btn.onClick.Invoke();
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
