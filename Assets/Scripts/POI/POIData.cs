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

    OnlineMapsMarker3D dynamicMarker;
    int defaultZoom = 18;

    void Start()
    {
        defaultZoom = OnlineMaps.instance.zoom;

        // Add OnClick events to dynamic markers
        dynamicMarker = OnlineMapsMarker3DManager.CreateItem(Longitude, Latitude, POIManager.instance.POI_Prefab);
        dynamicMarker.instance.name = string.Format("Marker_{0}", POI_Name);
        //dynamicMarker.OnClick += OnMarkerClick;
        //dynamicMarker.label = POI_Name;
        //dynamicMarker.SetDraggable();

        POIMarker markerPOI = dynamicMarker.instance.AddComponent<POIMarker>();
        markerPOI.data = this;
        markerPOI.OnClickPOI += OnMarkerClick;

        //Subscribe to zoom change
        OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
    }

    private void OnMarkerClick(POIMarker markerPOI)
    {
        //InfoBoxLayout.instance.OpenInfoBoxWithPOI(this);
    }

    private void OnChangeZoom()
    {
        //Example of scaling object
        //int zoom = OnlineMaps.instance.zoom;

        //float s = 10f / (2 << (zoom - 5));

        float originalScale = 1 << defaultZoom;
        float currentScale = 1 << OnlineMaps.instance.zoom;

        //ZoomHelper helper = dynamicMarker.instance.GetComponent<ZoomHelper>();
        //helper.SetGizmoRange(currentScale / originalScale);
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
