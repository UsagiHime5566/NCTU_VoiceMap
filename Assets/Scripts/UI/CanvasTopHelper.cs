using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTopHelper : MonoBehaviour
{
    public CheckLocaltionService LocaltionCheckFrom;
    public RectTransform WarningLocation;
    public RectTransform WarningCamera;
    void Awake()
    {
        LocaltionCheckFrom.OnApplicationRestartRequire += delegate {
            WarningLocation.gameObject.SetActive(true);
        };
    }
}
