using System;
using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float currentScale;
    [SerializeField] private float fireScale;
    [SerializeField] private float scaleDownDuration;
    
    public Rigidbody rb;
    public MeshRenderer meshRenderer;

    public void OnSpawn()
    {
        rb.isKinematic = true;
        meshRenderer.enabled = false;
    }

    public void OnFire()
    {
        rb.isKinematic = false;
        meshRenderer.enabled = true;
        transform.DOScale(currentScale, scaleDownDuration).From(fireScale);
    }
}