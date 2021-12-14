using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcVersionDisplay : MonoBehaviour
{
    [HimeLib.HelpBox] public string tip = "PC版輸出時，專用的視窗模式";
    public int width = 810;
    public int height = 1440;
    public int updateThreshold = 20;

    #if UNITY_STANDALONE_WIN

    void Start()
    {
        Screen.SetResolution(width, height, FullScreenMode.Windowed);
    }

    int index = 0;
    void Update(){

        index++;
        if(index % updateThreshold != 0)
            return;

        index = 0;
        
        if(width != Screen.width){

            #if !UNITY_EDITOR
            Debug.Log($"{Screen.currentResolution} , {Screen.width}x{Screen.height}");
            #endif

            width = Screen.width;
            height = (int)(width * (16.0f/9.0f));

            Screen.SetResolution(width, height, FullScreenMode.Windowed);

            return;
        }
        if(height != Screen.height){
            
            #if !UNITY_EDITOR
            Debug.Log($"{Screen.currentResolution} , {Screen.width}x{Screen.height}");
            #endif
            
            height = Screen.height;
            width = (int)(height / (16.0f/9.0f));

            Screen.SetResolution(width, height, FullScreenMode.Windowed);

            return;
        };

    }

    #endif
}