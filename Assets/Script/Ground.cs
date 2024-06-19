using Lean.Pool;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            LeanPool.Despawn(other.gameObject);
        }
    }
}
