using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 동물 장기 설명창UI 관리하는 스크립트
public class OrganDescription : MonoBehaviour
{
    public Canvas description;

    public bool isActive; // 이 변수에 따라 description SetActive() 관리

    void Start()
    {
        description.gameObject.SetActive(false);
        isActive = false;
    }

    void Update()
    {
        description.gameObject.SetActive(isActive);
    }

    public void setActiveUI()
    {
        isActive = !isActive;
    }
}
