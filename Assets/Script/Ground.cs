using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ground : MonoBehaviour
{
    private float _score = .0f;
    public Image bar_fill;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            LeanPool.Despawn(other.gameObject);
        }

        //pointer
        if (other.gameObject.CompareTag("box"))
        {
            _score += .4f;
            Debug.Log("score : +1");
            bar_fill.fillAmount += _score;

        }
        


    }
}
