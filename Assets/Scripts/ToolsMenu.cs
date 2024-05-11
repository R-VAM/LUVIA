using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsMenu : MonoBehaviour
{
    public bool isActive;

    void Start()
    {
        isActive = false;
    }

    void Update()
    {
        
    }

    // 손 동작을 인식해서 Tool메뉴 OPEN
    public void selectedByHandPose()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }

    // Tool메뉴 CLOSE
    public void unselectedByHandPose()
    {
        //gameObject.SetActive(false);
    }
}
