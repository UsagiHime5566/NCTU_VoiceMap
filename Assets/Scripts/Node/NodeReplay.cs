using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeReplay : NodeControlBase
{
    public ARCameraHelper ReplayCamera;
    public GameObject View_HowToUse;
    public Button BTN_Play;

    void Start(){
        BTN_Play?.onClick.AddListener(delegate {
            ArVideoManager.instance.CreateVideoCanvas(ReplayCamera.TrackerSlam);
            ReplayCamera.TrackingStart();
        });
    }

    public override void OnShowTodo(){
        View_HowToUse.SetActive(true);
        ReplayCamera.StartCamera(null);
    }

    // public override void OnShowFinTodo(){}

    public override void OnHideTodo(){
        ArVideoManager.instance.RemoveVideoCanvas();
        ReplayCamera.StopCamera();
    }
    // public override void OnHideFinTodo(){}
}
