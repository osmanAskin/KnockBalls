using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //spawnPrefab
    //public GameObject ballPrefab;


    //IsShoot
    [SerializeField] Rigidbody rb;
    [SerializeField] float Force = 10f; 
    [SerializeField] GameObject ball;

    //Target
    [SerializeField] GameObject Target;
    Plane plane = new Plane(Vector3.forward, 0);//plane nesnesi
    public Transform target;

    void Update()
    {
        Vector3 dir = target.position - ball.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            //IsShoot 
            rb.isKinematic = false;
            //ball.GetComponent<Rigidbody>().AddForce(dir * Force, ForceMode.Impulse);
            ball.GetComponent<Rigidbody>().AddForce(dir * Force, ForceMode.VelocityChange);


        }

        float dist;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out dist))
        {
            Target.SetActive(true);
            //Target
            Vector3 point = ray.GetPoint(dist);
            target.position = new Vector3(point.x, point.y, 0);

        }

        

    }

    public void SetVelocity(Vector3 velocity) 
    {
        rb.AddForce(velocity, ForceMode.VelocityChange);
    }

}

