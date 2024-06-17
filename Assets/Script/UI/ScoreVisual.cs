using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    private Platform _platform;//platform classindan actiona erismek icin referans 
    public int _score;
    public int _highScore;


    private void Start()
    {
        _platform = FindObjectOfType<Platform>();//nesne referansidir belirtilen turdeki nesneyi arar ve onun referansini dondurur
        _platform.OnHittedBoxCountChange += UpdateScore;//updateScore OnHittedBoxCountChange subscribe olmustur

        if (PlayerPrefs.HasKey("highscore")) 
        {
            _highScore = PlayerPrefs.GetInt("highscore");
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
        highScoreText.text = _highScore.ToString();


    }

    //private void OnEnable()
    //{
    //    HighScoreVisual.OnHighScoreActive;
    //}
}
