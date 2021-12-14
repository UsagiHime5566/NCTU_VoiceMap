using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialOrientation : MonoBehaviour
{
    [HimeLib.HelpBox] public string tip ="限制手機僅能直式";
    void Start()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
    }
}
