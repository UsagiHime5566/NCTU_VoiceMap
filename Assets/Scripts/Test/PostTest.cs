using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostTest : MonoBehaviour
{
    public NetworkManager networkManager;
    

    [ContextMenu("TestBoxList")]
    public void TestBoxList(){
        networkManager.API_GetBoxList(25.5566, 120.5566);
    }
}
