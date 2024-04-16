using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // EventTrigger를 사용하기 위해 추가

public class Start_Scene : MonoBehaviour
{
    public Canvas canvasToDisable; // 비활성화할 캔버스

    void Start()
    {
        // 이벤트 트리거를 가져와서 이벤트 리스너 추가
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick; // 버튼 클릭 이벤트
        entry.callback.AddListener((data) => { OnButtonClicked(); }); // 콜백 함수 등록
        trigger.triggers.Add(entry);
    }

    // 버튼 클릭 시 호출되는 함수
    void OnButtonClicked()
    {
        // 캔버스를 비활성화
        canvasToDisable.gameObject.SetActive(false);
    }
}
