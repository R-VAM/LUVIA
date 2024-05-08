using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingFrog : MonoBehaviour
{
    public Transform frogPosition;
    private GameObject CuttingLine1;
    private GameObject CuttingLine2;
    private GameObject CuttingLine3;
    private GameObject CuttingLine4;
    private GameObject CuttingLine5;
    private GameObject CuttingLine6;
    public GameObject Knife;
    public GameObject BeforeFrog;
    public GameObject AfterFrog;
    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        CuttingLine1 = BeforeFrog.transform.Find("CuttingLine1").gameObject;
        CuttingLine2 = BeforeFrog.transform.Find("CuttingLine2").gameObject;
        CuttingLine3 = BeforeFrog.transform.Find("CuttingLine3").gameObject;
        CuttingLine4 = BeforeFrog.transform.Find("CuttingLine4").gameObject;
        CuttingLine5 = BeforeFrog.transform.Find("CuttingLine5").gameObject;
        CuttingLine6 = BeforeFrog.transform.Find("CuttingLine6").gameObject;
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
            // 1초 동안 모든 선이 투명색이 됩니다.
            SetLineColor(Color.clear);
            yield return new WaitForSeconds(1f);

            // 1초 동안 모든 선이 빨간색이 됩니다.
            SetLineColor(Color.red);
            yield return new WaitForSeconds(1f);
        }

        // 모든 선이 빨간색이 된 후 Cut() 함수를 호출합니다.
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
