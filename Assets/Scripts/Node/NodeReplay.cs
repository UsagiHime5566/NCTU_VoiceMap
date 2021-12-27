using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeReplay : NodeControlBase
{
    public ARCameraHelper ReplayCamera;
    public GameObject View_HowToUse;
    public Button BTN_Play;
    public Canvas CoverLogo;

    void Start(){
        BTN_Play?.onClick.AddListener(delegate {
            ArVideoManager.instance.CreateVideoCanvas(ReplayCamera.TrackerSlam);
            ReplayCamera.TrackingStart();
        });
    }

    public override void OnShowTodo(){
        View_HowToUse.SetActive(true);
        ReplayCamera.StartCamera(null);
        CoverLogo.gameObject.SetActive(true);
    }

    // public override void OnShowFinTodo(){}

    public override void OnHideTodo(){
        ArVideoManager.instance.RemoveVideoCanvas();
        ReplayCamera.StopCamera();
        CoverLogo.gameObject.SetActive(false);
    }
    // public override void OnHideFinTodo(){}
}
