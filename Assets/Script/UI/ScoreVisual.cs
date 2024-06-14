using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private Platform _platform;//anlamadim (baþka classdan gelen referansi depolamak için)
    public int _score;

    private void Start()
    {
        _platform = FindObjectOfType<Platform>();
        _platform.OnBoxCountChange += UpdateScore;//kutular yok oldugunda OnBoxCountChangei tetikler
    }

    private void UpdateScore(int boxCount)
    {
        _score = boxCount;
        scoreText.text = "Score: " + _score;
    }
}
