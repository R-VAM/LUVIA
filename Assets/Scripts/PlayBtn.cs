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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void btnClick()
    {
        if (video.isPlaying)
        {
            video.Pause();
        }
        else
        {
            video.Play();
        }
    }
}
