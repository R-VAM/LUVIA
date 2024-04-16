using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPressed : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 현재는 태그가 tools인 모든 오브젝트를 삭제하는 상태
        // 나중에 추가 조건으로 특정 도구만 지우도록 수정
        GameObject[] toolsObjects = GameObject.FindGameObjectsWithTag("Tools");
        foreach (GameObject tool in toolsObjects)
        {
            Destroy(tool);
        }
    }
}
