using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VoidARBehaviour))]
public class ARCameraHelper : CameraHelperBase
{
    [Header("Void Type")]
    public TrackType trackType = TrackType.Slam;

    [Header("QR AR Target")]
    public GameObject QR_Target;

    [HideInInspector] public Transform TrackerSlam;     // AR會將SLAM物件貼合在該Transform 底下
    [HideInInspector] public GameObject currentTrack;

    [Header("Magic Effect")]
    public List<Transform> BornEffects;
    Transform lastEffect;

    [Header("Events")]
    public System.Action OnStartCameraSlam;
    public System.Action OnStartCameraQR;
    public System.Action OnPause;
    
    VoidARBehaviour VoidARHelper;

    int objectType = 0;
    
    protected  override void Awake() {
        base.Awake();
        VoidARHelper = GetComponent<VoidARBehaviour>();
        TrackerSlam = VoidARHelper.markerlessParent.transform;
    }

    // public override void SetupData(POIData data){
    //     ClearInstance();

    //     GameObject prefab = modelDatas.GetModelByName(data.artist_name);

    //     if(prefab == null)
    //         return;

    //     Debug.Log($"Use Prefab : {prefab.name}");

    //     if(trackType == TrackType.Slam){
    //         SetupObject3D(prefab, data);
    //     }

    //     // all camera will be called setup , so all instant should hide in initial
    //     TrackerSlam.gameObject.SetActive(false);
    // }

    // public void SetupObject3D(GameObject obj, POIData data){
    //     objectType = 0;
    //     currentTrack = Instantiate(obj, TrackerSlam);
    //     //OnModelTouch touch = currentTrack.GetComponent<OnModelTouch>();
    //     touch?.SetupData(data);
    // }
    
    // public void SetupFlatPicture2D(Sprite photo){
    //     objectType = 1;

    //     // Use for NCTU123 Old Picture
    //     if(POIManager.instance.SLAM_Prefab != null) {
    //         currentTrack = Instantiate(POIManager.instance.SLAM_Prefab, TrackerSlam);
    //         //IsPhoto comp = currentTrack.GetComponent<IsPhoto>();
    //         comp.SetPictureData(photo);
    //     }
    // }

    // Has no effect, it's a bug usage
    // public void SwitchCamera(){
    //     VoidARHelper.CameraIndex = (VoidARHelper.CameraIndex + 1) % 2;
    // }

    public override void StartCamera(System.Action callback){
        if(trackType == TrackType.Slam){
            VoidARHelper.StartAR(VoidARBase.EMarkerType.Markerless, () => {
                VisibleCamera(true);
                
                OnStartCameraSlam?.Invoke();
                callback?.Invoke();
            });
        }
        if(trackType == TrackType.QR){
            VoidARHelper.StartAR(VoidARBase.EMarkerType.Image, () => {
                VisibleCamera(true);
                QR_Target.SetActive(true);
                
                OnStartCameraQR?.Invoke();
                callback?.Invoke();
            });
        }
    }

    public override void ResumeCamera(System.Action callback){
        VoidARHelper.EnableAR(true);
        VisibleCamera(true);
        OnStartCameraSlam?.Invoke();
        callback?.Invoke();
    }

    public override void PauseCamera(){
        VisibleCamera(false);
        VoidARHelper.EnableAR(false);
        TrackerSlam.gameObject.SetActive(false);
        OnPause?.Invoke();
    }

    public override void StopCamera(){
        VisibleCamera(false);
        VoidARHelper.EnableAR(false);
        TrackerSlam.gameObject.SetActive(false);
    }

    public void TrackingStart(){
        TrackerSlam.gameObject.SetActive(true);
        
        VoidAR.GetInstance().startMarkerlessTracking();
        Debug.Log("Start Tracking");
    }

    public async void CreateBornEffect(System.Action callback){
        if(lastEffect != null)
            Destroy(lastEffect.gameObject);

        lastEffect = Instantiate(BornEffects[Random.Range(0, BornEffects.Count)], TrackerSlam);
        await Task.Delay(250);
        callback?.Invoke();
    }

    public void OnSlamReset(){
        TrackerSlam.gameObject.SetActive(false);
    }

    public enum TrackType
    {
        Slam = 0,
        QR = 1,
    }
}
