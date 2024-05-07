using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // 생성할 물체 프리팹
    public Transform spawnPoint1; // 물체가 생성될 위치1
    public Transform spawnPoint2; // 물체가 생성될 위치2


    // 개구리랑 고정핀이랑 충돌했을 때 고정핀 이동
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Animal") && objectPrefab != null && spawnPoint1 != null && spawnPoint2 != null)
        {
            // 첫 번째 스폰 위치에 물체를 생성
            Instantiate(objectPrefab, spawnPoint1.position, spawnPoint1.rotation);
            // 두 번째 스폰 위치에 물체를 생성
            Instantiate(objectPrefab, spawnPoint2.position, spawnPoint2.rotation);

            Destroy(collision.collider.gameObject);

            // 이 컴포넌트 자체를 삭제
            Destroy(this);
        }
    }
}
