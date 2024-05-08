using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalTray : MonoBehaviour
{
    public Transform frogPosition;
    public GameObject anesFrog;

    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;
    public GameObject L5;
    public GameObject L6;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            if (collision.gameObject.GetComponent<Animal>().state == Animal.FrogState.Anesthesia)
            {
                Destroy(collision.gameObject);
                Instantiate(anesFrog, frogPosition.position, frogPosition.rotation);
                L1.SetActive(true);
                L2.SetActive(true);
                L3.SetActive(true);
                L4.SetActive(true);
                L5.SetActive(true);
                L6.SetActive(true);
            }
        }
    }
}
