using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 손 동작을 인식해서 Tool메뉴 OPEN
    public void selectedByHandPose()
    {
        gameObject.SetActive(true);
    }

    // Tool메뉴 CLOSE
    public void unselectedByHandPose()
    {
        gameObject.SetActive(false);
    }
}
