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

    void Start(){
        NetworkManager.instance.OnProgressUpdate += UpdateProgressText;
        BTN_Cancel?.onClick.AddListener(CancelUpload);
    }

    void UpdateProgressText(float progress){
        float preview = Mathf.FloorToInt(progress * 100);
        TXT_Progress.text = $"{preview}%";
    }

    void CancelUpload(){
        NetworkManager.instance.AbortUploading();
    }

    void OnUploadFinished(){
        Doozy.Engine.GameEventMessage.SendEvent(DozzyEventUploadFin);

        UIPopup m_popup = UIPopupManager.GetPopup(DozzyPopupUploadFin);
        m_popup?.Show();

        Debug.Log("Upload finished!");
    }

    // public override void OnShowTodo(){}
    public override void OnShowFinTodo(){
        TXT_Progress.text = $"0%";
        NetworkManager.instance.StartUploadMedia(OnUploadFinished);
    }
    // public override void OnHideTodo(){}
    // public override void OnHideFinTodo(){}
}
