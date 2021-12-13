using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMap : NodeControlBase
{
    public Camera MapCamera;
    public override void OnShowTodo(){
        MapCamera.depth = 1;
    }
    // public override void OnShowFinTodo(){}

    public override void OnHideTodo(){
        
    }
    public override void OnHideFinTodo(){
        MapCamera.depth = -1;
    }
}
