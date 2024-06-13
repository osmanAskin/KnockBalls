using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI highScoreText;
    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected List<GameObject> cubeObjects;

    protected int _score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            //glasscubelar nasil tetiklenecek
            _score++;
            Debug.Log("Score: " + _score);
        }
    }
}
