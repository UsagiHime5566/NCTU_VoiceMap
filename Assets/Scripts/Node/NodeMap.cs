using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class NodeMap : NodeControlBase
{
    public Camera MapCamera;
    public string DozzyReplayPopupName;
    public string distanceTip = "";

    void Start(){
        POIManager.instance.OnUserArrivedPoi += UserArrivePoi;
        POIManager.instance.OnUserClickPoi += UserClickPoi;
    }

    public void UserArrivePoi(POIData data){
        UIPopup m_popup = UIPopupManager.GetPopup(DozzyReplayPopupName);

        //make sure that a popup clone was actually created
        if (m_popup == null)
            return;

        //set the achievement title and message
        m_popup.Data.SetLabelsTexts(data.Title, data.Content, distanceTip);
        m_popup.Data.Buttons[0].Interactable = true;
        //Debug.Log(m_popup.Data.LabelsCount);
        m_popup.Data.Labels[2].SetActive(false);

        var info = m_popup.GetComponent<PopupVideoInfo>();
        info.MediaFile = data.Media;

        //show the popup
        m_popup.Show();
    }

    public void UserClickPoi(POIData data){
        UIPopup m_popup = UIPopupManager.GetPopup(DozzyReplayPopupName);

        //make sure that a popup clone was actually created
        if (m_popup == null)
            return;

        //set the achievement title and message
        m_popup.Data.SetLabelsTexts(data.Title, data.Content, distanceTip);

        if(data.isNear){
            m_popup.Data.Buttons[0].Interactable = true;
            m_popup.Data.Labels[2].SetActive(false);

            var info = m_popup.GetComponent<PopupVideoInfo>();
            info.MediaFile = data.Media;
        } else {
            m_popup.Data.Buttons[0].Interactable = false;
            m_popup.Data.Labels[2].SetActive(true);
        }
        
        //show the popup
        m_popup.Show();
    }

    public override void OnShowTodo(){
        MapCamera.depth = 1;
        POIManager.instance.UserController.ColliderActive(true);
    }
    // public override void OnShowFinTodo(){}

    public override void OnHideTodo(){
        POIManager.instance.UserController.ColliderActive(false);
    }
    public override void OnHideFinTodo(){
        MapCamera.depth = -1;
    }
}
