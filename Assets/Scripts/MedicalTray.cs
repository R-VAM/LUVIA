using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalTray : MonoBehaviour
{
    public Transform frogPosition;
    public GameObject anesFrog;

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
            }
        }
    }
}
