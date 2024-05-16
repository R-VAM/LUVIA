using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // 생성할 물체 프리팹
    public Transform[] spawnPoints;
    public GameObject[] imageObject;

    private int spawnIndex = 0;

    // 개구리랑 고정핀이랑 충돌했을 때 고정핀 이동
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") && objectPrefab != null && spawnIndex < spawnPoints.Length)
        {
            // 현재 인덱스에 해당하는 위치에 물체를 생성
            Instantiate(objectPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            imageObject[spawnIndex].SetActive(true);

            // 다음 인덱스로 이동
            spawnIndex++;

            if (spawnIndex > 4)
            {
                Destroy(gameObject);
            }
        }
    }
}
