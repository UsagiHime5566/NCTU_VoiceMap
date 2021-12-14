using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public CameraHelperBase RecordCamera;
    public CameraHelperBase ArCamera;

    int i = 0_104_450_0;

    IEnumerator Start(){
        Debug.Log(i);
        yield return new WaitForSeconds(3);

        RecordCamera.StartCamera(() => {
            Debug.Log($"Camera started!");
        });
    }
}
