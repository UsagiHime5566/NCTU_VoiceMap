using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupVideoInfo : MonoBehaviour
{
    public Button BTN_Start;
    public string MediaFile;

    void Start(){
        BTN_Start?.onClick.AddListener(delegate {

            Vector2 gps = OnlineMapsLocationService.instance.position;
            NetworkManager.instance.API_GetBoxList(gps.y, gps.x, boxes => {
                if(boxes.box == null)
                    return;

                foreach (var item in boxes.box)
                {
                    if(item.media_filename.Contains(MediaFile)){
                        MediaFile = item.media_filename;
                        ArVideoManager.instance.PrepareMediaFile = MediaFile;
                    }
                }
            });
            
        });
    }
}