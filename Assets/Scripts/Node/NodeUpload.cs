using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUpload : NodeControlBase
{
    public TextMeshProUGUI TXT_Progress;
    public Button BTN_Cancel;

    void Start(){
        BTN_Cancel?.onClick.AddListener(CancelUpload);
    }

    public void CancelUpload(){
        
    }

    // public override void OnShowTodo(){}
    // public override void OnShowFinTodo(){}

    // public override void OnHideTodo(){}
    // public override void OnHideFinTodo(){}
}
