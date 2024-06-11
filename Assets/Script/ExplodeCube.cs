using System.Collections.Generic;
using UnityEngine;

public class ExplodeCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private List<Rigidbody> childRigidbodies;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            rb.gameObject.SetActive(false);
            
            foreach (var childRb in childRigidbodies)
            {
                childRb.gameObject.SetActive(true);
                childRb.transform.SetParent(null);
                childRb.velocity = rb.velocity;
            }
        }
    }
}
