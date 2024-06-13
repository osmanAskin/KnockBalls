using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI scoreText;

    private Platform _platform;
    protected int _score;

    private void Start()
    {
        _platform = FindObjectOfType<Platform>();
        _platform.OnBoxCountChange += UpdateScore;
    }

    private void UpdateScore(int boxCount)
    {
        _score = boxCount;
        scoreText.text = "Score: " + _score;
    }
}
