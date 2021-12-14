using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopRecord : MonoBehaviour
{
    [HimeLib.HelpBox] public string tip = "將使用者資料暫存至RecordManager";
    public InputField INP_Title;
    public InputField INP_Content;
    public Button BTN_StartRecord;

    void Start(){
        BTN_StartRecord?.onClick.AddListener(InputVideoInfos);
    }

    public void InputVideoInfos(){
        RecordManager.instance.ComingTitle = INP_Title.text;
        RecordManager.instance.ComingContent = INP_Content.text;
    }
}
