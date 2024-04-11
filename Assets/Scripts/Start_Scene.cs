using UnityEngine;
using UnityEngine.UI;

public class Start_Scene : MonoBehaviour
{
    public Canvas canvasToDisable;
    public Camera mainCamera;
    public float cameraMoveSpeed = 5f;
    public float canvasFadeSpeed = 2f;

    private bool isButtonClicked = false;

    // 초기 카메라의 위치와 회전을 저장하는 변수
    private Vector3 initialCameraPosition = new Vector3(0, 1, 0);
    private Quaternion initialCameraRotation = Quaternion.Euler(0, 0, 0);

    // 이동할 위치와 회전값 변수
    public Vector3 targetPosition = new Vector3(0, 1.5f, 0);
    public Quaternion targetRotation = Quaternion.Euler(42, 0, 0);

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // 카메라의 초기 위치와 회전을 저장
        initialCameraPosition = mainCamera.transform.position;
        initialCameraRotation = mainCamera.transform.rotation;
    }

    void Update()
    {
        // 버튼이 클릭되면 캔버스를 서서히 비활성화하고 카메라를 설정된 위치로 이동시킴
        if (isButtonClicked)
        {
            // 캔버스를 서서히 비활성화
            canvasToDisable.gameObject.SetActive(false);

            // 카메라를 서서히 이동시킴
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, targetRotation, cameraMoveSpeed * Time.deltaTime);

            // 이동이 완료되면 캔버스를 완전히 비활성화하고 이동을 중단
            if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.01f)
            {
                canvasToDisable.gameObject.SetActive(false);
                isButtonClicked = false;
            }
        }
    }

    void OnButtonClick()
    {
        // 버튼이 클릭되면 이동 시작
        isButtonClicked = true;
    }

    // 씬이 리로드될 때 카메라의 초기 위치와 회전으로 리셋
    void OnEnable()
    {
        mainCamera.transform.position = initialCameraPosition;
        mainCamera.transform.rotation = initialCameraRotation;
    }
}
