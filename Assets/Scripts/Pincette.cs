using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Grab;

public class Pincette : MonoBehaviour
{
    public enum State // 핀셋의 상태 {손에 잡힌 상태, 손에 잡히지 않은 상태}
    {
        Released,
        Grabbed
    }

    public State state;

    public HandGrabInteractable handInteract;
    public HandGrabInteractor handGrabInteractorR;

    public Transform handTransform; // 핀셋을 잡았을 때 손에 위치할 Transform

    MeshRenderer meshRenderer;

    private void Awake()
    {
       meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        /*if (handGrabInteractorR.IsGrabbing)
        {
            if (handGrabInteractorR.CurrentGrabType() == GrabTypeFlags.Palm)
            {
                setRed();
            }
            else if (handGrabInteractorR.CurrentGrabType() == GrabTypeFlags.Pinch)
            {
                setBlack();
            }
        }*/

        // Grabbed 상태일 때
        if (handGrabInteractorR.IsGrabbing)
        {
            setBlack();
            state = State.Grabbed;
        }
        // Released 상태일 때
        else
        {
            setRed();
            state = State.Released;
        }

    }


    private void setRed()
    {
        meshRenderer.material.color = Color.red;
    }

    private void setBlack()
    {
        meshRenderer.material.color = Color.black;
    }

    private void setGreen()
    {
        meshRenderer.material.color = Color.green;
    }
}
