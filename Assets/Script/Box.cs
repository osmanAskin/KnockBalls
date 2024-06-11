using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 100f;
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Vector3 contactPoint = collision.contacts[0].point; // Get first contact point
            Vector3 direction = contactPoint - transform.position; // Direction from box to contact point

            // Apply force in the direction of impact
            rb.AddForce(direction.normalized * force, ForceMode.Impulse);
        }
    }
}
