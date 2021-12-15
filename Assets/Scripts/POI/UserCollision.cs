using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("POI"))
        {
            var markerHelper = other.GetComponent<MarkerHelper>();

            markerHelper?.TrigUserArriveMarker();

            //Shake Device
            Handheld.Vibrate();

            if(other.gameObject.transform.childCount == 0)
                return;

            Transform child = other.gameObject.transform.GetChild(0);
            if(child != null)
                child.GetComponent<Renderer>().material.color = POIManager.instance.UserCollisionColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("POI"))
        {
            var markerHelper = other.GetComponent<MarkerHelper>();

            markerHelper?.LeavePOI();

            if(other.gameObject.transform.childCount == 0)
                return;

            Transform child = other.gameObject.transform.GetChild(0);
            if(child != null)
                child.GetComponent<Renderer>().material.color = Color.white;
            
        }
    }
}