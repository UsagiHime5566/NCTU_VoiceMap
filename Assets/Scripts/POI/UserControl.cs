using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    public BoxCollider boxCollider;
    void Start()
    {
        //boxCollider.enabled = false;
    }

    public void ColliderActive(bool val){
        boxCollider.enabled = val;
    }
}
