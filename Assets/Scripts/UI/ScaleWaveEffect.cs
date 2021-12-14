using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleWaveEffect : MonoBehaviour
{
    public float finalSize;
    public float duration;
    public float delay;

    Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(new Vector3(finalSize, finalSize, finalSize), duration))
            .Join(material.DOFade(0, duration))
            .AppendInterval(delay)
            .SetLoops(-1, LoopType.Restart);
    }
}
