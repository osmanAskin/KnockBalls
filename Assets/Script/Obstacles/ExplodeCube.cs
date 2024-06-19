using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ExplodeCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private List<Rigidbody> childRigidbodies;
    [SerializeField] private float multiplyVelocity;
    private AudioManager audioManager;

    public void Start() 
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            var ballRb = other.gameObject.GetComponent<Rigidbody>();
            rb.gameObject.SetActive(false);

            foreach (var childRb in childRigidbodies)
            {
                childRb.gameObject.SetActive(true);
                childRb.transform.SetParent(null); 
                childRb.velocity = ballRb.velocity * multiplyVelocity;
                childRb.transform.DOScale(0f, 1.25f).SetDelay(.3f).SetEase(Ease.Linear);
            }
            
            audioManager.Play(SoundType.GlassBoxBreak);
        }
    }
}
