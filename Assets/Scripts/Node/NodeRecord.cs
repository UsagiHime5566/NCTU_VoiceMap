using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeRecord : NodeControlBase
{
    public CameraHelperBase RecordCamera;
    public Button BTN_StartRecord;
    public Button BTN_Back;
    public string DozzyGotoUpload;

    [Header(@"Settings"), Range(5f, 60f), Tooltip(@"Maximum duration that button can be pressed.")]
    public float maxDuration = 10f;

    [Header(@"UI")]
    public Image countdown;


    bool isRecording = false;
    bool normalEnd = false;

    void Start()
    {
        BTN_StartRecord?.onClick.AddListener(StartRecord);
        BTN_Back?.onClick.AddListener(StopRecord);
    }

    public void StartRecord()
    {
        isRecording = true;
        normalEnd = false;
        BTN_StartRecord.gameObject.SetActive(false);
        StartCoroutine(Countdown());
    }

    public void StopRecord()
    {
        isRecording = false;
    }

    private IEnumerator Countdown()
    {
        // Start recording
        RecordManager.instance.recordHelper.StartRecording();

        // Animate the countdown
        var startTime = Time.time;
        while (isRecording)
        {
            var ratio = 1 - ((Time.time - startTime) / maxDuration);
            if(ratio <= 0f){
                isRecording = false;
                normalEnd = true;
            }
            countdown.fillAmount = ratio;
            yield return null;
        }
        
        // Stop recording
        RecordManager.instance.recordHelper.StopRecording(normalEnd);

        //Goto Upload
        if(normalEnd){
            Doozy.Engine.GameEventMessage.SendEvent(DozzyGotoUpload);
        }
    }

    private void UIReset()
    {
        countdown.fillAmount = 1.0f;
        BTN_StartRecord.gameObject.SetActive(true);
    }

    private void OnApplicationPause(bool pauseStatus) {
        // true 代表已經暫停
        if(pauseStatus == true){
            isRecording = false;
        } else {
            normalEnd = false;
            UIReset();
        }
    }

    // public override void OnShowTodo(){}
    public override void OnShowFinTodo()
    {
        UIReset();
        RecordCamera.StartCamera(null);
    }

    public override void OnHideTodo(){
        RecordCamera.StopCamera();
    }
    // public override void OnHideFinTodo(){}
}
