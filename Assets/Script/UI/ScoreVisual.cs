using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private Platform _platform;//anlamadim (ba�ka classdan gelen referansi depolamak i�in)
    public int _score;

    private void Start()
    {
        _platform = FindObjectOfType<Platform>();
        _platform.OnHittedBoxCountChange += UpdateScore;//kutular yok oldugunda OnBoxCountChangei tetikler
    }

    private void UpdateScore(int boxCount)
    {
        _score = boxCount;
        scoreText.text = "Score: " + _score;
    }
}
