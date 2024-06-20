using DG.Tweening;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class Ball : MonoBehaviour
{
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
    }

    public void BallScaleIncrease()
    {
        if (transform != null)
        {
            rb.transform.DOScale(1f, 10f).SetLoops(2,LoopType.Yoyo);
        }
  



    }

    }


