using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ExplodeCube : MonoBehaviour
{
    //particle
    GameObject ParticleCube;
    GameObject ParticleCube1;
    GameObject ParticleCube2;
    GameObject ParticleCube3;

    public Rigidbody ParticleRb;
    public Rigidbody ParticleRb1;
    public Rigidbody ParticleRb2;
    public Rigidbody ParticleRb3;

    public MeshRenderer ParticleMeshRenderer;
    public MeshRenderer ParticleMeshRenderer1;
    public MeshRenderer ParticleMeshRenderer2;
    public MeshRenderer ParticleMeshRenderer3;

    public BoxCollider ParticleCollider;
    public BoxCollider ParticleCollider1;
    public BoxCollider ParticleCollider2;
    public BoxCollider ParticleCollider3;

    //glassCube
    GameObject GlassCube;
    public MeshRenderer GlassMeshRenderer;
    public BoxCollider GlassBoxCollider;

    private void Start()
    {
        ParticleRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        { 
            GlassMeshRenderer.enabled= false;
            GlassBoxCollider.enabled= false;

            ParticleRb.isKinematic = false;
            ParticleRb1.isKinematic = false;
            ParticleRb2.isKinematic = false;
            ParticleRb3.isKinematic = false;

            ParticleMeshRenderer.enabled= true;
            ParticleMeshRenderer1.enabled= true;
            ParticleMeshRenderer2.enabled= true;
            ParticleMeshRenderer3.enabled= true;


            ParticleCollider.enabled= true;
            ParticleCollider1.enabled= true;
            ParticleCollider2.enabled= true;
            ParticleCollider3.enabled = true;

            /*
            if(ParticleCollider == true) 
            {
                ParticleCollider.radius += .2f;
                ParticleCollider1.radius += .2f;
                ParticleCollider2.radius += .2f;
                ParticleCollider3.radius += .2f;
                Debug.Log("ParticleCollider True");

            }
            */

        }
    }
}
