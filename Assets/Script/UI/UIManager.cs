using System;
using TMPro;
using UnityEngine;
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

    private void Start()
    {
        ballShooter = FindObjectOfType<BallShooter>();//fail onbulletfinishe subscribe oluyor
        ballShooter.OnBulletFinish += ActivateFail;
        

        platform = FindObjectOfType<Platform>();
        platform.OnBoxCountFinish += ActivateWin;
        platform.OnBoxCountFinish += FillAmount;
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
    }

    private void ActivateFail() 
    {
        loseObject.SetActive(true);
    }

    private void FillAmount() 
    {
        barFillImage.fillAmount += .4f;
    }

    
}


    