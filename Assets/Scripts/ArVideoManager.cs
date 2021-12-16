using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArVideoManager : SoraLib.SingletonMono<ArVideoManager>
{
    public VideoCanvas prefab_VideoCanvas;
    public string PrepareMediaFile;

    string lastUrl;
    VideoCanvas lastInstance;

    public void CreateVideoCanvas(Transform parent){
        CreateVideoCanvas(Vector3.zero);
        lastInstance.transform.parent = parent;
    }

    public void CreateVideoCanvas(Vector3 pos){
        string url = NetworkManager.instance.serverURL + NetworkManager.instance.api_getMedia + "/" + PrepareMediaFile;
        CreateVideoCanvas(pos, url);
    }

    public void CreateVideoCanvas(Vector3 pos, string url){
        if(string.IsNullOrEmpty(url))
            return;

        if(lastUrl == url){
            lastInstance.transform.position = pos;
            return;
        }

        if(lastInstance)
            Destroy(lastInstance.gameObject);

        lastUrl = url;
        lastInstance = Instantiate(prefab_VideoCanvas, pos, Quaternion.identity);
        lastInstance.Play(url);
    }

    public void RemoveVideoCanvas(){
        lastUrl = "";
        if(lastInstance)
            Destroy(lastInstance.gameObject);
    }
}
