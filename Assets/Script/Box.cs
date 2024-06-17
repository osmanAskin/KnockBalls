using UnityEngine;

public class Box : MonoBehaviour
{
    // [SerializeField] Rigidbody rb;
    // [SerializeField] float force = 100f;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            // Vector3 contactPoint = collision.contacts[0].point; // Get first contact point
            // Vector3 direction = contactPoint - transform.position; // Direction from box to contact point
            // // Apply force in the direction of impact
            // rb.AddForce(direction.normalized * force, ForceMode.Impulse);//boxlara addForce ekleniyor

            //sound
            audioManager.Play(SoundType.DefaultBoxBreak);
        }
    }
}
