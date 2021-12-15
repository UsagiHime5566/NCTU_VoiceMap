using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupVideoInfo : MonoBehaviour
{
    public Button BTN_Start;
    public string Url;

    void Start(){
        BTN_Start?.onClick.AddListener(delegate {
            ArVideoManager.instance.PrepareMediaFile = Url;
        });
    }
}