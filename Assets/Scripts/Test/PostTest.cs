using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostTest : MonoBehaviour
{
    public NetworkManager networkManager;
    

    void Start(){
        Debug.Log(System.DateTime.Parse("Tue, 07 Dec 2021 21:38:36 GMT"));
    }


    [ContextMenu("TestUploadAddress")]
    public void TestUploadAddress(){
        networkManager.API_UploadAccess(25.1387, 121.4598);
    }

    [ContextMenu("TestBoxList")]
    public void TestBoxList(){
        networkManager.API_GetBoxList(25.5566, 120.5566);
    }
    
    [ContextMenu("Upload file")]
    public void UploadFile(){
        string path = @"I:\UnityProject\NCTU_VoiceMap\54ba7479b4934ca0abc91a8e7bed1fc3.mp4";
    }
}
