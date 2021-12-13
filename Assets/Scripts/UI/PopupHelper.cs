using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class PopupHelper : MonoBehaviour
{
    public void CreatePopup(string popName)
    {
        //get a clone of the UIPopup, with the given PopupName, from the UIPopup Database 
        UIPopup m_popup = UIPopupManager.GetPopup(popName);

        //make sure that a popup clone was actually created
        if (m_popup == null)
            return;

        // //set the achievement icon
        // m_popup.Data.SetImagesSprites(achievement.Icon);
        // //set the achievement title and message
        // m_popup.Data.SetLabelsTexts(achievement.Achievement, achievement.Description);

        //show the popup
        m_popup.Show();
    }
}
