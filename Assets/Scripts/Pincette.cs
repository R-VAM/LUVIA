using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.HandGrab;

public class Pincette : MonoBehaviour
{
    public HandGrabInteractable handInteract;
    public HandGrabInteractor handGrabInteractorR;

    MeshRenderer meshRenderer;

    private void Awake()
    {
       meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
       if (handGrabInteractorR.IsGrabbing)
       {
            setRed();
       }
       else
       {
            setBlack();
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
}
