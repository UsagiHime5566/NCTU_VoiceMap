using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPTest : MonoBehaviour
{
    public string videoURL = "";
    public Vector3 v_pos = new Vector3(0, 1, 0);

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ArVideoManager.instance.CreateVideoCanvas(v_pos, videoURL);
        }
    }
}
