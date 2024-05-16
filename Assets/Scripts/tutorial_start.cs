using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_start : MonoBehaviour
{
    public GameObject imageObject;
    public GameObject imageObject_info;

    public float delayTime = 3f; // 이미지가 활성화된 후 비활성화될 때까지의 대기 시간

    void Start()
    {
        // 이미지가 활성화된 경우에만 지정된 시간 후에 비활성화하는 코루틴 시작
        if (imageObject.activeSelf)
        {
            StartCoroutine(DisableImageAfterDelay(delayTime));
        }
    }

    // 일정 시간이 지난 후에 이미지를 비활성화하는 코루틴
    IEnumerator DisableImageAfterDelay(float delay)
    {
        // delay 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // 이미지 비활성화
        imageObject.SetActive(false);
        //StartCoroutine(DisableImageAfterDelay(delayTime));
        imageObject_info.SetActive(true);
    }

}