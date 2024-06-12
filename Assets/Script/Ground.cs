using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO: herhangi ui ile alakali birsey bu classta olmiycak
// TODO: highscore'u da score'u arttirdigin yerde kontrol et
public class Ground : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image barFillImage;

    private int _score;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HightScore", _score).ToString();
        HighScore();
    }

    public void HighScore() 
    {
        if (_score > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", _score);
            highScoreText.text = _score.ToString();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            LeanPool.Despawn(other.gameObject);
        }

        if (other.gameObject.CompareTag("box"))
        {
            Debug.Log(++_score);
            scoreText.text = _score.ToString();
            barFillImage.fillAmount += _score;
        }
    }
}
