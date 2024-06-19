using UnityEngine;

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
}


