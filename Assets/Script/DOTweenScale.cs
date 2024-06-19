using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenScale : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubeObject;

    public void DoScale()
    {
        foreach (var cube in cubeObject)
        {
            // Her bir GameObject üzerinde DOScale çaðrýsý yapýlýyor
            cube.transform.DOScale(Vector3.one / 10, 1);
        }
    }
}
