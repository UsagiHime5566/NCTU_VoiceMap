﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArVideoManager : SoraLib.SingletonMono<ArVideoManager>
{
    public VideoCanvas prefab_VideoCanvas;

    string lastUrl;
    VideoCanvas lastInstance;

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
}