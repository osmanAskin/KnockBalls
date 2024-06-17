using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private Platform _platform;//platform classindan actiona erismek icin referans 
    private int _score;
    private int _highScore;

    private void Start()
    {
        _platform = FindObjectOfType<Platform>();//nesne referansidir belirtilen turdeki nesneyi arar ve onun referansini dondurur
        _platform.OnHittedBoxCountChange += UpdateScore;//updateScore OnHittedBoxCountChange subscribe olmustur

        if (PlayerPrefs.HasKey("highscore")) 
        {
            _highScore = PlayerPrefs.GetInt("highscore");
            highScoreText.text = "High Score : "+ _highScore;
        }
    }

    private void UpdateScore(int boxCount)
    {
        _score = boxCount;
        scoreText.text = "Score: " + _score;

        if(_score >= _highScore) 
        {
            _highScore = _score;
            PlayerPrefs.SetInt("highscore", _highScore);
        }
    }

    //private void OnEnable()
    //{
    //    HighScoreVisual.OnHighScoreActive;
    //}
}
