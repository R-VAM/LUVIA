using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jusagi : OneGrabFreeTransformer, ITransformer
{

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    public bool isGrabbed;
    public float collisionDuration;

    public GameObject imageObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public new void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
    }

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡을 때 호출됨
    public new void BeginTransform()
    {
        isGrabbed = true;

        base.BeginTransform();
        onobjectGrabbed?.Invoke(gameObject);

        detectGrab(); // 잡았을 때 detectGrab() 호출
    }

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡고 이동시킬 때마다 호출됨
    public new void UpdateTransform()
    {
        base.UpdateTransform();
        onObjectMoved?.Invoke(gameObject);
    }

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡았다가 놓았을 때 호출됨
    public new void EndTransform()
    {
        isGrabbed = false;

        onObjectReleased?.Invoke(gameObject);

        detectGrab(); // detectGrab()을 호출함
    }

    void detectGrab()
    {

        if (isGrabbed)
        {

        }
        else
        {

        }
    }



    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            Animal cshAnimal = collision.gameObject.GetComponent<Animal>();

            // collision이 'Animal'이고 잡혀있는 상태라면
            if(cshAnimal.isGrabbed)
            {
                // 마취 상태로 변경하는 함수 호출
                cshAnimal.doAnes();
            }
        }
    }*/

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            collisionDuration += Time.deltaTime;
            
            if(collisionDuration > 3f)
            {
                Animal cshAnimal = collision.gameObject.GetComponent<Animal>();
                cshAnimal.doAnes();
                imageObject.SetActive(true);
            }
        }
    }
}
