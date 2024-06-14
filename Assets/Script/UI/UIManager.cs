using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //first scene settings 
    [SerializeField] private Animator LayoutAnimator;
    
    //mainmenu canvas
    [SerializeField] private GameObject progressBarObject;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject restartMenuObject;
    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject loseObject;
    private BallShooter ballShooter;
    private Platform platform;

    private void Start()
    {
        ballShooter = FindObjectOfType<BallShooter>();
        ballShooter.OnBulletFinish += ActivateFail;
        
        platform = FindObjectOfType<Platform>();
        platform.OnBoxCountFinish += ActivateWin;
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
}


    