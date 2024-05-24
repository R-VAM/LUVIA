using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // 생성할 물체 프리팹
    //public Transform[] spawnPoints;
    public GameObject[] imageObject;
    public Transform spawnPoints1;
    public Transform spawnPoints2;
    public Transform spawnPoints3;
    public Transform spawnPoints4;


    // 개구리랑 고정핀이랑 충돌했을 때 고정핀 이동
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") && objectPrefab != null)
        {
            Debug.Log("OK");

            // 현재 인덱스에 해당하는 위치에 물체를 생성
            Instantiate(objectPrefab, spawnPoints1.position, spawnPoints1.rotation);
            Instantiate(objectPrefab, spawnPoints2.position, spawnPoints2.rotation);
            Instantiate(objectPrefab, spawnPoints3.position, spawnPoints3.rotation);
            Instantiate(objectPrefab, spawnPoints4.position, spawnPoints4.rotation);

            //imageObject[spawnIndex].SetActive(true);


        }
    }
}
