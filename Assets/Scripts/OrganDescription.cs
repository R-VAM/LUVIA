using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 동물 장기 설명창UI 관리하는 스크립트
public class OrganDescription : MonoBehaviour
{
    public Canvas description;
    public GameObject heartPanel;
    public GameObject liverPanel;
    public GameObject scleraPanel;
    public GameObject intestinePanel;
    public GameObject lungPanel;
    public GameObject kidneyPanel;
    public GameObject bladderPanel;

    public bool isActive; // 이 변수에 따라 description SetActive() 관리

    void Start()
    {
        description.gameObject.SetActive(false);
        isActive = false;
    }

    void Update()
    {
        //description.gameObject.SetActive(isActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Organ"))
        {
            description.gameObject.SetActive(true);
            DisplayOrganInfo(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Organ"))
        {
            description.gameObject.SetActive(false);
            HideOrganInfo();
        }
    }

private void DisplayOrganInfo(string organName)
{
    HideOrganInfo();

    switch (organName)
    {
        case "heart":
            heartPanel.SetActive(true);
            break;
        case "liver":
            liverPanel.SetActive(true);
            break;
        case "Sclera":
            scleraPanel.SetActive(true);
            break;
        case "intestine":
            intestinePanel.SetActive(true);
            break;
        case "lung":
            lungPanel.SetActive(true);
            break;
        case "kidneys":
            kidneyPanel.SetActive(true);
            break;
        case "bladder":
            bladderPanel.SetActive(true);
            break;
    }
}

    private void HideOrganInfo()
    {
        heartPanel.SetActive(false);
        liverPanel.SetActive(false);
        scleraPanel.SetActive(false);
        intestinePanel.SetActive(false);
        lungPanel.SetActive(false);
        kidneyPanel.SetActive(false);
        bladderPanel.SetActive(false);
    }

    public void setActiveUI()
    {
        isActive = !isActive;
        //description.gameObject.SetActive(isActive);
    }

}
