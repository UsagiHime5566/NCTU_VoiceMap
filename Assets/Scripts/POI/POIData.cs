using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIData : MonoBehaviour
{
    public string POI_Name;
    public double Latitude;
    public double Longitude;
    public string Title;
    public string Content;
    public OnlineMapsMarker3D connectedMarker;

    MarkerHelper connectedMarkerHelper;
    int defaultZoom = 18;
    void Start()
    {
        defaultZoom = OnlineMaps.instance.zoom;

        // Add OnClick events to dynamic markers
        connectedMarker = OnlineMapsMarker3DManager.CreateItem(Longitude, Latitude, POIManager.instance.POI_Prefab);
        connectedMarker.instance.name = string.Format("Marker_{0}", POI_Name);

        //不好用
        //dynamicMarker.OnClick += OnMarkerClick;
        //dynamicMarker.label = POI_Name;
        //dynamicMarker.SetDraggable();

        connectedMarkerHelper = connectedMarker.instance.GetComponent<MarkerHelper>();
        connectedMarkerHelper.data = this;
        connectedMarkerHelper.OnMarkerClick += OnMarkerClick;

        //Subscribe to zoom change
        OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
    }

    private void OnMarkerClick()
    {
        POIManager.instance.OnUserClickPoi?.Invoke(this);
    }

    private void OnChangeZoom()
    {
        float originalScale = 1 << defaultZoom;
        float currentScale = 1 << OnlineMaps.instance.zoom;

        // Sora: Zoom Marker Collision
        connectedMarkerHelper.SetGizmoRange(currentScale / originalScale);
    }

    private void OnValidate() {
        gameObject.name = string.Format("POI_{0}", POI_Name);
    }

    // public void OldPictureSetter(Sprite spt){
    //     oldPicture = spt;
    // }

    // public void NowPictureSetter(Sprite spt){
    //     nowPicture = spt;
    // }
}
