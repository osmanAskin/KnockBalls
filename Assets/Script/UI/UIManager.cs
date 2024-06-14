using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

public class UIManager : ScoreVisual
{
    //first scene settings 
    [SerializeField] private Animator LayoutAnimator;
    
    //mainmenu canvas
    [SerializeField] private GameObject progressBarObject;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject restartMenuObject;

    [SerializeField] private GameObject mainMenuObject;

    //Win
    [SerializeField] private GameObject winObject;

    //Lose
    [SerializeField] private GameObject loseObject;
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

    public void WinTextWrite() 
    {
       winObject.SetActive(true);
    }

    public void LoseTextWrite() 
    {
        loseObject.SetActive(true);
    }
}


    