using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class PlayBtn : MonoBehaviour
{
    public TextMeshProUGUI btnText;
    public VideoPlayer video;


    public void btnClick()
    {
        if(video.isPlaying)
        {
            video.Pause();
            btnText.text = "Play";
        }
        else
        {
            video.Play();
            btnText.text = "Pause";
        }
    }
}
