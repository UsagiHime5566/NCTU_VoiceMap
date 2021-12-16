using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamTest : MonoBehaviour
{
    public ARCameraHelper ArCamera;
    void Start()
    {
        ArCamera.StartCamera(null);

        ArCamera.TrackingStart();
    }

}
