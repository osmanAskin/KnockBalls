using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator LayoutAnimator;
    
    [SerializeField] private GameObject progressBarObject;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject restartMenuObject;
    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject loseObject;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Image barFillImage;
    private BallShooter ballShooter;
    private Platform platform;
    private ExplodeCube explodeCube;

    private void Start()
    {
        explodeCube = FindObjectOfType<ExplodeCube>();


        ballShooter = FindObjectOfType<BallShooter>();
        ballShooter.OnBulletFinish += CheckFailOrWinScreen;//fail onbulletfinishe subscribe oluyor


        platform = FindObjectOfType<Platform>();
        platform.OnBoxCountFinish += ActivateWin;
        platform.OnBoxCountFinish += FillAmount;
    }


    private void CheckFailOrWinScreen() 
    {
        var boxCountOnPlatform = platform.CalculateBoxCountOnPlatform();
        if(boxCountOnPlatform == 0) 
        {
            ActivateWin();
        }

        else  
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                if (platform.CalculateBoxCountOnPlatform() > 0)//1 saniye sonra ca�rildi�i icin methodun kendisini referans olarak aliyor cunki 1 saniyede platformun �zerindeki cublar de�isebilir 
                {
                    ActivateFail();
                }
            });
            
        }


    }


    public void LayoutSettingsOpen()
    {
        LayoutAnimator.SetTrigger("slide_in");
    }

    public void LayoutSettingsClose()
    {
        LayoutAnimator.SetTrigger("slide_out");
    }

    public void TapToButton()
    {
        mainMenuObject.SetActive(false);

        progressBarObject.SetActive(true);
        bulletObject.SetActive(true);
        restartMenuObject.SetActive(true);
    }

    private void ActivateWin() 
    {
        winObject.SetActive(true);
        DOVirtual.DelayedCall(2f, NextLevel);
    }

    private void ActivateFail() 
    {
        loseObject.SetActive(true);
        DOVirtual.DelayedCall(2f, RestartLevel);
    }

    private void FillAmount() 
    {
        barFillImage.fillAmount += 2;
    }
    
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("next");//3 kere calisiyor 
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restart");//restartta ayni sekilde
    }
}


    