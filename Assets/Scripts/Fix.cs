using Oculus.Interaction;
using UnityEngine;

public class Fix : OneGrabFreeTransformer, ITransformer
{
    public GameObject objectPrefab; // 생성할 물체 프리팹
    public Transform spawnPoint1; // 물체가 생성될 위치1
    public Transform spawnPoint2; // 물체가 생성될 위치2

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    public bool isGrabbed;

    public new void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
    }

    // 이 물체를 잡을 때 호출됨
    public new void BeginTransform()
    {
        isGrabbed = true;

        base.BeginTransform();
        onobjectGrabbed?.Invoke(gameObject);

        detectGrab(); // 잡았을 때 detectGrab() 호출
    }

    // 이 물체를 잡고 이동시킬 때마다 호출됨
    public new void UpdateTransform()
    {
        base.UpdateTransform();
        onObjectMoved?.Invoke(gameObject);
    }

    // 이 물체를 잡았다가 놓았을 때 호출됨
    public new void EndTransform()
    {
        isGrabbed = false;

        onObjectReleased?.Invoke(gameObject);

        detectGrab(); // detectGrab()을 호출함
    }

    void detectGrab()
    {
        // 필요한 경우에만 추가적인 동작 수행
    }

    // 개구리랑 고정핀이랑 충돌했을 때 고정핀 이동
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Fix") && objectPrefab != null && spawnPoint1 != null && spawnPoint2 != null)
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
