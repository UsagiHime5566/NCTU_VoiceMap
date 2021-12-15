using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeReplay : NodeControlBase
{
    public GameObject View_HowToUse;
    public Button BTN_Play;

    void Start(){
        BTN_Play?.onClick.AddListener(delegate {
            ArVideoManager.instance.CreateVideoCanvas(new Vector3(0, 0, 0));
        });
    }

    public override void OnShowTodo(){
        View_HowToUse.SetActive(true);
    }

    // public override void OnShowFinTodo(){}

    // public override void OnHideTodo(){}
    // public override void OnHideFinTodo(){}
}
