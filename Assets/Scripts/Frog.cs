using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
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

    private Animator animator;

    void Start()
    {
        state = FrogState.Idle;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        checkState(); // 상태 체크
    }

    void checkState()
    {
        if (state == FrogState.Idle)
        {
            // Idle Action 함수 작성
        }
        else if (state == FrogState.Grabbed)
        {
            frogGrabbed();
        }
        else if (state == FrogState.Anesthesia)
        {
            // 마취됐을 때 Action 함수 작성
        }
    }

    public void frogGrabbed()
    {
        
    }
}
