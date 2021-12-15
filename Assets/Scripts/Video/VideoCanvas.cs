using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCanvas : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Transform OBJ_Scale;

    public void Play(string url){
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();
    }

    public void SetScale(float scale){
        OBJ_Scale.localScale = new Vector3(scale, scale, scale);
    }
}
