using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodeCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private List<Rigidbody> childRigidbodies;//childboxlari tutuyo

    private AudioManager audioManager;

    
    public void Start() 
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            rb.gameObject.SetActive(false);//ball ile tetiklendiðinde parent kapaniyo

            foreach (var childRb in childRigidbodies)//childlar aciliyo
            {
                childRb.gameObject.SetActive(true);
                childRb.transform.SetParent(null);//anlamadim: alt küpün baðlý oldugu gameobjectden ayrýlýyor 
                childRb.velocity = rb.velocity;//ana küpün hýzýný childlara devirdaim edilir
            }

            audioManager.Play(SoundType.GlassBoxBreak);
        }
    }
}
