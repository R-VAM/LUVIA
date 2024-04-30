using UnityEngine;

public class Start_Scene : MonoBehaviour
{
    public Canvas canvasToDisable; // 비활성화할 캔버스

    private void OnTriggerEnter(Collider collision)
    {
        canvasToDisable.gameObject.SetActive(false);
    }
}
