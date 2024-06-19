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
            // Her bir GameObject �zerinde DOScale �a�r�s� yap�l�yor
            cube.transform.DOScale(Vector3.one / 10, 1);
        }
    }
}
