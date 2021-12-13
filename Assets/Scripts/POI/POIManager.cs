using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ideafixxxer.CsvParser;
using System.Linq;
using UnityEngine.Networking;

public class POIManager : SoraLib.SingletonMono<POIManager>
{
    public GameObject POI_Prefab;
    public GameObject SLAM_Prefab;
    public List<Sprite> IconPack;
    string ServerURL = "";


    public Action OnAppInfosDownloaded;

    IEnumerator Start()
    {
        while(CheckIntenetConnection.instance.InternetStats == false){
            yield return null;
        }
        DownloadManager.GoogleGetCSV(ImportPOIData, OnlineDataManager.instance.webService, OnlineDataManager.instance.sheetID, OnlineDataManager.instance.POI_pageID);
        yield return new WaitForSeconds(2.0f);
        DownloadManager.GoogleGetCSV(GetInfos, OnlineDataManager.instance.webService, OnlineDataManager.instance.sheetID, OnlineDataManager.instance.Infos_PageID);
    }

    public void ImportPOIData(string csvFile)
    {

        //讀入 CSV 檔案，使其分為 string 二維陣列
        CsvParser csvParser = new CsvParser();
        string[][] csvTable = csvParser.Parse(csvFile);

        var tempList = transform.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {
            DestroyImmediate(child.gameObject);
        }

        for (int i = 1; i < csvTable.Length; i++)
        {
            string poiName = csvTable[i][(int)CSVIndex.NAME];
            string title = csvTable[i][(int)CSVIndex.TITLE];
            string content = csvTable[i][(int)CSVIndex.CONTENT];
            double Lat_Obj, Lon_Obj;
            double.TryParse(csvTable[i][(int)CSVIndex.LAT], out Lat_Obj);
            double.TryParse(csvTable[i][(int)CSVIndex.LON], out Lon_Obj);

            //Debug.Log(poiName + "\n" + Lat_User + "\n" + Lon_User + "\n" + Lat_Goal + "\n" + Lon_Goal + "\n" + description + "\n");

            GameObject poi = new GameObject();
            poi.tag = "POI";
            POIData data = poi.AddComponent<POIData>();
            data.POI_Name = poiName;
            data.Latitude = Lat_Obj;
            data.Longitude = Lon_Obj;
            data.Title = title;
            data.Content = content;

            poi.transform.parent = transform;
            poi.name = string.Format("POI_{0}", poiName);
        }
    }

    public void GetInfos(string csvFile){
        //讀入 CSV 檔案，使其分為 string 二維陣列
        CsvParser csvParser = new CsvParser();
        string[][] csvTable = csvParser.Parse(csvFile);

        if(csvTable.Length == 0 || csvTable[0].Length == 0){
            Debug.LogError("Online info is error format");
            return;
        }

        string url = csvTable[1][0];
        string ver = csvTable[1][1];
        string about = csvTable[1][2];
        string contact = csvTable[1][3];
        string staff = csvTable[1][4];
        string initPosition = csvTable[1][5];

        try {
            double lat = 0, lon = 0;
            if(!string.IsNullOrEmpty(initPosition)){
                string[] slt = initPosition.Split(',');
                double.TryParse(slt[0], out lat);
                double.TryParse(slt[1], out lon);

                OnlineMaps.instance.SetPosition(lon, lat);
                Debug.Log($"Set map view to {lat}, {lon}");
            }
        }
        catch(Exception e) {
            Debug.Log(e.Message.ToString());
        }

        ServerURL = url;
        Debug.Log($"Use Server URL : {ServerURL}");

        //AboutMeLayout.instance.UpdateAboutMe(about_title, about_content);
        OnAppInfosDownloaded?.Invoke();
    }

    IEnumerator PingConnect()
    {
        bool result = false;
        WaitForSeconds wait = new WaitForSeconds(5);
        while (!result)
        {
            UnityWebRequest request = new UnityWebRequest("http://google.com");
            yield return request.SendWebRequest();
            if (request.error != null)
            {
                Debug.Log("Have no Internet, retry after 5 seconds...");
            }
            else
            {
                result = true;
            }
            yield return wait;
        }

        Debug.Log("Network access success.");
    }

    public enum CSVIndex
    {
        NAME = 0,
        LAT = 1,
        LON = 2,
        TITLE = 3,
        CONTENT = 4,
    }
}
