using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : SoraLib.SingletonMono<NetworkManager>
{
    [Header(@"API URL")]
    public string serverURL = "https://media.iottalktw.com";
    public string getUploadAccess = "/api/getUploadAccess";
    public string upload = "/api/upload";
    public string getBoxList = "/api/getBoxList";
    public string getMedia = "/api/media";


    public string currentUUID;

    public string uploadUUID;
    void Start()
    {
        currentUUID = System.Guid.NewGuid().ToString().Replace("-", "");

        //Debug.Log($"Create UUID : {currentUUID}");
        //Debug.Log(GetLocationJSON(24.7867, 121.9977));
        //StartCoroutine(HttpPost(GetLocationJSON(24.7867, 121.9977)));

        //HttpGetBoxList();
    }

    

    public void API_UploadAccess(double lat, double lon)
    {
        StartCoroutine(HttpPostJSON(serverURL + getUploadAccess, GetLocationJSON(lat, lon), json => {
            DataUUID data = GetDataUUID(json);
            uploadUUID = data.uuid;
        }));
    }

    public void API_UploadFile(string filePath, string fileID){
        StartCoroutine(HttpPostFile(serverURL + upload, filePath, fileID));
    }

    public void API_GetBoxList(double lat, double lon)
    {
        StartCoroutine(HttpPostJSON(serverURL + getBoxList, GetLocationUUIDJSON(lat, lon, currentUUID), json => {
            
        }));
    }

    public void API_GetFile(string fileID){
        StartCoroutine(HttpGetFile(fileID));
    }

    public IEnumerator HttpPostJSON(string url, string json, System.Action<string> callback)
    {
        // 這個方法會把json裡的文字編碼成url code , 例如 { 變成 %7B
        // var request = UnityWebRequest.Post(url, json);
        // request.SetRequestHeader("Content-Type", "application/json");

        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError){
            Debug.Log("Network error has occured: " + request.GetResponseHeader(""));
        } else {
            Debug.Log("Success: " + request.downloadHandler.text);
            
            callback?.Invoke(request.downloadHandler.text);
        }

        // byte[] results = request.downloadHandler.data;
        // Debug.Log("Data: " + System.String.Join(" ", results));
    }

    public IEnumerator HttpPostFile(string url, string filePath, string fileName){

        yield return null;
    }

    public IEnumerator HttpGetFile(string fileName){
        yield return null;
    }

    public string GetLocationJSON(double lat, double lon)
    {
        LocationJSON json = new LocationJSON() { latitude = lat, longitude = lon };
        return JsonUtility.ToJson(json);
    }

    public string GetLocationUUIDJSON(double lat, double lon, string uuid)
    {
        LocationUUIDJSON json = new LocationUUIDJSON() { latitude = lat, longitude = lon, uid = uuid };
        return JsonUtility.ToJson(json);
    }

    public DataUUID GetDataUUID(string json){
        return JsonUtility.FromJson<DataUUID>(json);
    }

    public class LocationJSON
    {
        public double latitude;
        public double longitude;
    }

    public class LocationUUIDJSON
    {
        public double latitude;
        public double longitude;
        public string uid;
    }

    public class DataUUID
    {
        public string expire;
        public double latitude;
        public double longitude;
        public string timestamp;
        public string uuid;
    }
}
