using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_Active : MonoBehaviour
{
    public GameObject imageObject; // 활성화할 이미지 GameObject

    void Start()
    {
        // 4초 후에 이미지를 활성화하는 코루틴 시작
        Invoke("ActivateImage", 4f);
    }

    // 이미지를 활성화하는 메서드
    void ActivateImage()
    {
        if (!imageObject.activeSelf)
        {
            imageObject.SetActive(true);
        }
    }

}
