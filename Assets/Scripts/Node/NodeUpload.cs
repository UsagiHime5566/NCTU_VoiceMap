using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Doozy.Engine.UI;

public class NodeUpload : NodeControlBase
{
    public TextMeshProUGUI TXT_Progress;
    public Button BTN_Cancel;

    public string DozzyEventUploadFin;
    public string DozzyPopupUploadFin;
    
    bool uploading = false;

    void Start(){
        BTN_Cancel?.onClick.AddListener(CancelUpload);
    }

    public void CancelUpload(){
        uploading = false;
    }

    IEnumerator StartUpload(){

        float progress = 0f;
        while(progress < 1 && uploading){
            yield return null;
            progress += 0.005f;
            float preview = Mathf.FloorToInt(progress * 100);
            TXT_Progress.text = $"{preview}%";
        }

        if(progress >= 1 && uploading){
            uploading = false;
            Doozy.Engine.GameEventMessage.SendEvent(DozzyEventUploadFin);
            UIPopup m_popup = UIPopupManager.GetPopup(DozzyPopupUploadFin);
            m_popup?.Show();

            Debug.Log("Upload finished!");
        }

        uploading = false;
    }

    // public override void OnShowTodo(){}
    public override void OnShowFinTodo(){
        uploading = true;
        StartCoroutine(StartUpload());
    }

    // public override void OnHideTodo(){}
    // public override void OnHideFinTodo(){}
}
