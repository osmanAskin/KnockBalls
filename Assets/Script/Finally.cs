using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finally : MonoBehaviour
{
    int isEmpty = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box")) 
        {
            ++isEmpty;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            --isEmpty;
            Debug.Log(isEmpty + "obje");

            if (isEmpty == 0)
            {
                Debug.Log("NextLevel");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }  
    
    }
    }
