using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NodeTitle : NodeControlBase
{
    public CanvasGroup title;
    public float fadeTime = 1;


    // public override void OnShowTodo(){}
    public override void OnShowFinTodo(){
        title.DOFade(0, fadeTime);
    }

    // public override void OnHideTodo(){}
    // public override void OnHideFinTodo(){}
}
