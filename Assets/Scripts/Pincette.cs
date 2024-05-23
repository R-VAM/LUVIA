using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Grab;

public class Pincette : MonoBehaviour
{
/*    public enum State // 핀셋의 상태 {손에 잡힌 상태, 손에 잡히지 않은 상태}
    {
        Released,
        Grabbed
    }*/

    //public State state;

    public HandGrabInteractable handInteract;
    public HandGrabInteractor handGrabInteractorL;

    public Transform handTransform; // 핀셋을 잡았을 때 손에 위치할 Transform

    public GameObject pincette;
    public GameObject GrabbedPincette;

    public Transform pincettePos;
    public Transform HeightStandard;

    bool pincetteGrabbing = false;

    private float grabPincetteTime;

    private void Update()
    {
        if (pincette.transform.position.y > HeightStandard.transform.position.y) 
        {
            if (handGrabInteractorL.CurrentGrabType() == GrabTypeFlags.Pinch) 
            {
                if (handGrabInteractorL.IsGrabbing)
                {
                    grabPincetteTime += Time.deltaTime;

                    if (grabPincetteTime > 2.0f)
                    {
                        pincetteGrabbing = true;
                        GrabbedPincette.SetActive(true);
                        pincette.SetActive(false);
                    }
                }
            }
            else if (handGrabInteractorL.CurrentGrabType() == GrabTypeFlags.Palm)
            {
                grabPincetteTime = 0;
                pincetteGrabbing = false;
                GrabbedPincette.SetActive(false);
                pincette.SetActive(true);
            }
            else
            {
                grabPincetteTime = 0;
                pincetteGrabbing = false;
                GrabbedPincette.SetActive(false);
                pincette.SetActive(true);
            }
        }


    }

    public void freePincette()
    {
        if(pincetteGrabbing == true)
        {
            //transform.position = new Vector3(-0.3f, 1.34f, 1.5f);
            GrabbedPincette.SetActive(false);
            pincette.SetActive(true);
        }

    }

}

            // Grabbed 상태일 때
            /*if (handGrabInteractorL.IsGrabbing)
            {
                state = State.Grabbed;
            }
            // Released 상태일 때
            else
            {
                state = State.Released;
            }*/
