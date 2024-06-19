using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float multiplyVelocity;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            var ballRb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = ballRb.velocity * multiplyVelocity;
            audioManager.Play(SoundType.DefaultBoxBreak);
        }
    }
}
