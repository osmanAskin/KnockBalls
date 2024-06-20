using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private Platform _platform;
    private int _score;
    private int _highScore;

    private void Start()
    {
        _platform = FindObjectOfType<Platform>();
        _platform.OnHittedBoxCountChange += UpdateScore;

        if (PlayerPrefs.HasKey("highscore"))
        {
            _highScore = PlayerPrefs.GetInt("highscore");
            highScoreText.text = "High Score : " + _highScore;
        }
    }

    private void UpdateScore(int boxCount)
    {
        _score = boxCount;
        scoreText.text = "Score: " + _score;

        if (_score >= _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("highscore", _highScore);
        }
    }
}
