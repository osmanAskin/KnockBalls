using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    //score
    private int _score;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI score;

    public Image bar_fill;

    private void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HightScore", _score).ToString();
        highScore();
    }

    public void highScore() 
    {
        if (_score > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", _score);
            HighScore.text = _score.ToString();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            LeanPool.Despawn(other.gameObject);
        }

        //pointer
        if (other.gameObject.CompareTag("box"))
        {
            Debug.Log(++_score);
            score.text = _score.ToString();

            //bu sistem deðiþecek rastgele float deðer eklenmeyecek her seviyden sonra 1 kutu dolacak
            //_score += 1f;
            bar_fill.fillAmount += _score;
            

        }


        
    }
}
