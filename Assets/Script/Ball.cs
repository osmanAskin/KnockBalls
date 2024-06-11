using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //reset
    Vector3 spawnPos;
    public Rigidbody rb;

    //boxForce variables
    [SerializeField] float force = 1000 * 3;


    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("box")) 
        {
            rb.AddForce(Vector3.forward * 100);
        }
    }

    */

    
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("reset"))
    //    {
    //        //reset
    //        Debug.Log("collision!");
    //        //RepositionBall();
    //        rb.isKinematic = true;
    //    }

    //    if (collision.gameObject.CompareTag("box"))
    //    {
    //        //box force
    //        Debug.Log("Box Force!!");
    //        rb.AddForce(Vector3.forward * force);
    //        rb.AddForce(Vector3.up * force);
    //    }
    //}


    //reset
    // public void RepositionBall()
    //{
    //    LeanPool.Despawn(gameObject);
    //    //gameObject.SetActive(false);
    //    transform.position = spawnPos;
    //    gameObject.SetActive(true);
    //}
}


