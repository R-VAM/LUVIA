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
        if (collision.gameObject.CompareTag("Line1"))
        {
            var LineRenderer1 = CuttingLine1.GetComponent<Renderer>();
            LineRenderer1.material.SetColor("_Color", Color.red);
            Debug.Log(count);
            count = 2;
        }
        if (collision.gameObject.CompareTag("Line2"))
        {
            var LineRenderer2 = CuttingLine2.GetComponent<Renderer>();
            LineRenderer2.material.SetColor("_Color", Color.red);
            Debug.Log(count);
            count = 3;
        }
        if (collision.gameObject.CompareTag("Line3"))
        {
            var LineRenderer3 = CuttingLine3.GetComponent<Renderer>();
            LineRenderer3.material.SetColor("_Color", Color.red);
            Debug.Log(count);
            count = 4;
        }
        if (collision.gameObject.CompareTag("Line4"))
        {
            var LineRenderer4 = CuttingLine4.GetComponent<Renderer>();
            LineRenderer4.material.SetColor("_Color", Color.red);
            Debug.Log(count);
            count = 5;
        }
        if (collision.gameObject.CompareTag("Line5"))
        {
            var LineRenderer5 = CuttingLine5.GetComponent<Renderer>();
            LineRenderer5.material.SetColor("_Color", Color.red);
            Debug.Log(count);
            count = 6;
        }
        if (collision.gameObject.CompareTag("Line6"))
        {
            var LineRenderer6 = CuttingLine6.GetComponent<Renderer>();
            LineRenderer6.material.SetColor("_Color", Color.red);
            Debug.Log(count);
            AllLineRed();
        }
    }

    private void AllLineRed()
    {
        StartCoroutine(FlashLines());
    }

    private IEnumerator FlashLines()
    {
        for (int i = 0; i < 3; i++)
        {
            // 1�� ���� ��� ���� ������� �˴ϴ�.
            SetLineColor(Color.clear);
            yield return new WaitForSeconds(1f);

            // 1�� ���� ��� ���� �������� �˴ϴ�.
            SetLineColor(Color.red);
            yield return new WaitForSeconds(1f);
        }

        // ��� ���� �������� �� �� Cut() �Լ��� ȣ���մϴ�.
        Cut();
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
        Destroy(BeforeFrog);
        Instantiate(AfterFrog, frogPosition.position, frogPosition.rotation);
    }
}
