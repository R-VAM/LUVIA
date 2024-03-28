using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsMenu : MonoBehaviour
{
    public GameObject cam;
    public Transform rightHand;


    private Transform pos;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void selectedByHandPose()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = rightHand.position;
    }

    public void unselectedByHandPose()
    {
        gameObject.SetActive(false);
    }
}
