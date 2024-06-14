using TMPro;
using UnityEngine;

public class BulletVisual : MonoBehaviour//mantýðý scoreVisual ile ayni
{
    [SerializeField] private TextMeshProUGUI bulletText;

    private BallShooter ballShooter;

    private void Start()
    {
        ballShooter = FindObjectOfType<BallShooter>();
        ballShooter.OnBulletCountChange += UpdateBulletCount;
        UpdateBulletCount(ballShooter.bulletCount);
    }

    private void UpdateBulletCount(int count)
    {
        bulletText.text = "X " + count; 
    }
}