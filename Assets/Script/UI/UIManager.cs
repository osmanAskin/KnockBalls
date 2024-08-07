using DG.Tweening;
using TMPro;
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
    private bool sceneChanged;

    private void Start()
    {
        ballShooter = FindObjectOfType<BallShooter>();
        ballShooter.OnBulletFinish += CheckFailOrWinScreen;
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
                if (platform.CalculateBoxCountOnPlatform() > 0)
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
        if (sceneChanged) return;
        sceneChanged = true;
        
        winObject.SetActive(true);
        DOVirtual.DelayedCall(2f, NextLevel);
    }

    private void ActivateFail() 
    {
        if (sceneChanged) return;
        sceneChanged = true;
        
        loseObject.SetActive(true);
        DOVirtual.DelayedCall(2f, RestartLevel);
    }

    private void FillAmount() 
    {
        barFillImage.fillAmount += 2;
    }
    
    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;


        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Loading next scene: " + nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0); 
            Debug.Log("Starting from the beginning.");
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restart");
    }
}


    