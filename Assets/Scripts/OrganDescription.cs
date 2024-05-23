using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 동물 장기 설명창UI 관리하는 스크립트
public class OrganDescription : MonoBehaviour
{
    public Canvas description;

    public GameObject heartPanel;
    public Button heartPlayBtn;
    public TextMeshProUGUI heartBtnText;

    public GameObject liverPanel;
    public Button liverPlayBtn;
    public TextMeshProUGUI liverBtnText;

    public GameObject scleraPanel;
    // public Button scleraPlayBtn;  // 동영상이 없음

    public GameObject intestinePanel;
    public Button intestinePlayBtn;
    public TextMeshProUGUI intestineBtnText;

    public GameObject lungPanel;
    public Button lungPlayBtn;
    public TextMeshProUGUI lungBtnText;

    public GameObject kidneyPanel;
    // public Button kidneyPlayBtn;  // 동영상이 없음

    public GameObject bladderPanel;
    public Button bladderPlayBtn;
    public TextMeshProUGUI bladderBtnText;

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
                heartPlayBtn.gameObject.SetActive(true);
                heartBtnText.text = "Pause";

                break;
            case "liver":
                liverPanel.SetActive(true);
                liverPlayBtn.gameObject.SetActive(true);
                liverBtnText.text = "Pause";

                break;
            case "Sclera":
                scleraPanel.SetActive(true);
                // scleraPlayBtn.gameObject.SetActive(true);

                break;
            case "intestine":
                intestinePanel.SetActive(true);
                intestinePlayBtn.gameObject.SetActive(true);
                intestineBtnText.text = "Pause";

                break;
            case "lung":
                lungPanel.SetActive(true);
                lungPlayBtn.gameObject.SetActive(true);
                lungBtnText.text = "Pause";

                break;
            case "kidneys":
                kidneyPanel.SetActive(true);
                // kidneyPlayBtn.gameObject.SetActive(true);

                break;
            case "bladder":
                bladderPanel.SetActive(true);
                bladderPlayBtn.gameObject.SetActive(true);
                bladderBtnText.text = "Pause";

                break;
        }
    }

    private void HideOrganInfo()
    {
        heartPanel.SetActive(false);
        heartPlayBtn.gameObject.SetActive(false);

        liverPanel.SetActive(false);
        liverPlayBtn.gameObject.SetActive(false);

        scleraPanel.SetActive(false);
        // scleraPlayBtn.gameObject.SetActive(false);

        intestinePanel.SetActive(false);
        intestinePlayBtn.gameObject.SetActive(false);

        lungPanel.SetActive(false);
        lungPlayBtn.gameObject.SetActive(false);

        kidneyPanel.SetActive(false);
        // kidneyPlayBtn.gameObject.SetActive(false);

        bladderPanel.SetActive(false);
        bladderPlayBtn.gameObject.SetActive(false);

    }

    public void setActiveUI()
    {
        isActive = !isActive;
        //description.gameObject.SetActive(isActive);
    }

}
