using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HimeLib;

public class EmulatorPositionKeyboard : MonoBehaviour
{
    [HelpBox] public string tip = "當啟用GPS模擬時，由此Script控制GPS目前資料";
    public float moveSpeed = 1;

    OnlineMapsLocationService ls;
    void Start()
    {
        ls = OnlineMapsLocationService.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (ls == null)
            return;
        if(!ls.useGPSEmulator)
            return;

        if(Input.GetKey(KeyCode.W)){
            ls.emulatorPosition = ls.emulatorPosition + new Vector2(0, 1) * moveSpeed * 0.00001f;
        }
        if(Input.GetKey(KeyCode.A)){
            ls.emulatorPosition = ls.emulatorPosition + new Vector2(-1, 0) * moveSpeed * 0.00001f;
        }
        if(Input.GetKey(KeyCode.S)){
            ls.emulatorPosition = ls.emulatorPosition + new Vector2(0, -1) * moveSpeed * 0.00001f;
        }
        if(Input.GetKey(KeyCode.D)){
            ls.emulatorPosition = ls.emulatorPosition + new Vector2(1, 0) * moveSpeed * 0.00001f;
        }
    }
}
