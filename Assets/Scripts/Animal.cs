using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : OneGrabFreeTransformer, ITransformer
{
    // 개구리가 어떤 상태인지를 나타냄
    public enum FrogState
    {
        Idle,
        Grabbed,
        Anesthesia
    };

    // 개구리의 상태를 저장하는 변수
    public FrogState state;

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    private Animator animator;

    public bool isGrabbed;  // 개구리가 손에 잡힌 상태인지
    public bool isAnesed;   // 개구리가 마취된 상태인지

    public GameObject imageObject;


    public new void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
    }

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡을 때 호출됨
    public new void BeginTransform()
    {
        isGrabbed = true;
        state = FrogState.Grabbed;

        imageObject.SetActive(true);

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

    void Start()
    {
        state = FrogState.Idle;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        checkState(); // 상태 체크
    }

    void detectGrab()
    {

        if (isAnesed)
        {
            
        }
        else
        {
            state = FrogState.Idle;
            animator.SetBool("isGrabbed", isGrabbed);
        }
    }

    void checkState()
    {
        if (state == FrogState.Idle)
        {
            // Idle Action
            
        }
        else if (state == FrogState.Grabbed)
        {
            // 잡혔을 때 Action
            animator.SetBool("isGrabbed", isGrabbed);
            frogGrabbed();
        }
        else if (state == FrogState.Anesthesia)
        {
            // 마취됐을 때 Action

            // 애니메이터 비활성화
            animator.enabled = false;
        }
    }

    public void frogGrabbed()
    {
        
    }

    public void doAnes()
    {
        state = FrogState.Anesthesia;
        isAnesed = true;

        // 마취 됐는지 확인하기 위해 디버깅 용도로 크기 키우기 - 정상 작동
        //gameObject.transform.localScale += new Vector3(2f, 2f, 2f);
    }
}
