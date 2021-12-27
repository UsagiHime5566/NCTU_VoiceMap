using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
using TMPro;
using System.IO;

public class VideoCanvas : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RenderTexture textureRender;
    public Transform OBJ_Scale;

    public List<GameObject> VideoLoading;
    public List<TextMeshPro> TXT_Progress;

    void Awake(){
        videoPlayer.prepareCompleted += PrepareFinished;
        //Debug.Log("Video Created.");
    }

    public void Play(string url){
        textureRender.Release();
        StartCoroutine(this.LoadVideoFromThisURL(url));
        Debug.Log($"Start Play Video. {url}");

        // try {
        //     videoPlayer.Play();
        // } catch (System.Exception e){
        //     videoPlayer.Stop();
        //     Debug.LogError(e.Message);
        // }
    }

    void PrepareFinished(VideoPlayer vp){
        foreach (var text in TXT_Progress)
        {
            text.gameObject.SetActive(false);
            text.text = "0%";
        }
        LoadingUI(false);
        vp.Play();
    }

    public void ResetVideo(){
        foreach (var text in TXT_Progress)
        {
            text.gameObject.SetActive(true);
            text.text = "0%";
        }
        LoadingUI(true);
    }

    public void SetScale(float scale){
        OBJ_Scale.localScale = new Vector3(scale, scale, scale);
    }

    public void LoadingUI(bool val){
        foreach (var item in VideoLoading)
        {
            item.SetActive(val);
        }
    }
    
    private IEnumerator LoadVideoFromThisURL(string _url)
    {
        UnityWebRequest _videoRequest = UnityWebRequest.Get (_url);

        var asyncOp = _videoRequest.SendWebRequest();

        while(!asyncOp.isDone){
            //OnProgressUpdate?.Invoke(asyncOp.progress);
            float preview = Mathf.FloorToInt(asyncOp.progress * 100);
            foreach (var text in TXT_Progress)
            {
                text.text = $"{preview}%";
            }
            yield return null;
        }

        if (_videoRequest.isDone == false || _videoRequest.error != null)
        {
            Debug.Log ("Request = " + _videoRequest.error );
        }

        Debug.Log ("Video Done - " + _videoRequest.isDone);

        byte[] _videoBytes = _videoRequest.downloadHandler.data;

        string _pathToFile = Path.Combine (Application.persistentDataPath, "temp_movie.mp4");
        File.WriteAllBytes (_pathToFile, _videoBytes);
        Debug.Log (_pathToFile);

        PrepareThisURLInVideo (_pathToFile);
        yield return null;
    }


    void PrepareThisURLInVideo(string _url)
    {
        videoPlayer.source = UnityEngine.Video.VideoSource.Url;
        videoPlayer.url = _url;
        videoPlayer.Prepare ();
    }
}
