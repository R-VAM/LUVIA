using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingFrog : MonoBehaviour
{
    public Transform frogPosition;
    public GameObject CuttingLine1;
    public GameObject CuttingLine2;
    public GameObject CuttingLine3;
    public GameObject CuttingLine4;
    public GameObject CuttingLine5;
    public GameObject CuttingLine6;
    public GameObject Knife;
    public GameObject BeforeFrog;
    public GameObject AfterFrog;
    
    private int count = 1;

    Color newcolor = Color.clear;
    Color redcolor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        Color newcolor = Color.red;
        if (collision.gameObject.CompareTag("Line1") && count == 1)
        {
            CuttingLine1.GetComponent<Renderer>().material.SetColor("_Color", redcolor);
            Debug.Log(count);
            count = 2;
        }
        if (collision.gameObject.CompareTag("Line2") && count == 2)
        {
            CuttingLine2.GetComponent<Renderer>().material.SetColor("_Color", redcolor);
            Debug.Log(count);
            count = 3;
        }
        if (collision.gameObject.CompareTag("Line3") && count == 3)
        {
            CuttingLine3.GetComponent<Renderer>().material.SetColor("_Color", redcolor);
            Debug.Log(count);
            count = 4;
        }
        if (collision.gameObject.CompareTag("Line4") && count == 4)
        {
            CuttingLine4.GetComponent<Renderer>().material.SetColor("_Color", redcolor);
            Debug.Log(count);
            count = 5;
        }
        if (collision.gameObject.CompareTag("Line5") && count == 5)
        {
            CuttingLine5.GetComponent<Renderer>().material.SetColor("_Color", redcolor);
            Debug.Log(count);
            count = 6;
        }
        if (collision.gameObject.CompareTag("Line6") && count == 6)
        {
            count = 0;
            CuttingLine6.GetComponent<Renderer>().material.SetColor("_Color", redcolor);
            Debug.Log(count);
            AllLineRed();
        }
    }

    private void AllLineRed()
    {
        StartCoroutine(FlashLines());
        // 모든 선이 빨간색이 된 후 Cut() 함수를 호출합니다.
        StartCoroutine(DelayedCut()); // 3초 후에 Cut() 함수 실행
    }

    private IEnumerator DelayedCut()
    {
        yield return new WaitForSeconds(6f); // 3초 대기
        Cut(); // Cut() 함수 실행
    }

    private IEnumerator FlashLines()
    {
        for (int i = 0; i < 3; i++)
        {
            // 1초 동안 모든 선이 투명색이 됩니다.
            SetLineColor(newcolor);
            yield return new WaitForSeconds(1f);

            // 1초 동안 모든 선이 빨간색이 됩니다.
            SetLineColor(redcolor);
            yield return new WaitForSeconds(1f);
        }
    }

    private void SetLineColor(Color color)
    {
        CuttingLine1.GetComponent<Renderer>().material.SetColor("_Color", color);
        CuttingLine2.GetComponent<Renderer>().material.SetColor("_Color", color);
        CuttingLine3.GetComponent<Renderer>().material.SetColor("_Color", color);
        CuttingLine4.GetComponent<Renderer>().material.SetColor("_Color", color);
        CuttingLine5.GetComponent<Renderer>().material.SetColor("_Color", color);
        CuttingLine6.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void Cut()
    {
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("BeforeCutFrog");
        /*
        Destroy(BeforeFrog);
        Destroy(CuttingLine1);
        Destroy(CuttingLine2);
        Destroy(CuttingLine3);
        Destroy(CuttingLine4);
        Destroy(CuttingLine5);
        Destroy(CuttingLine6);
        */
        // BeforeFrog.SetActive(false);
        foreach (GameObject frog in frogs)
        {
            Destroy(frog);
        }
        CuttingLine1.SetActive(false);
        CuttingLine2.SetActive(false);
        CuttingLine3.SetActive(false);
        CuttingLine4.SetActive(false);
        CuttingLine5.SetActive(false);
        CuttingLine6.SetActive(false);
        Instantiate(AfterFrog, frogPosition.position, frogPosition.rotation);
    }
}
