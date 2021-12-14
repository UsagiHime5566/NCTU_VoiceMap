using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class MarkerHelper : MonoBehaviour
{
    public Transform GizmoColliRange;
    
    [Header("Runtime data")]
    public POIData data;


    public Action OnMarkerClick;
    SphereCollider eventCollider;
    float defaultSize;
    void Awake()
    {
        eventCollider = GetComponent<SphereCollider>();
        defaultSize = eventCollider.radius;
    }

    public void SetGizmoRange(float src){
        eventCollider.radius = defaultSize * src;

        if(GizmoColliRange)
            GizmoColliRange.localScale = new Vector3(defaultSize * src * 2, defaultSize * src * 2, defaultSize * src * 2);
    }

    public void TrigUserArriveMarker(){
        POIManager.instance.OnUserArrivedPoi?.Invoke(data);
    }
}
