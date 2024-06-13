using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TODO: ui ile ilgili genel seyler burda olmali
public class UIManager : Score
{
    //first scene settings 
    [SerializeField] private Animator LayoutAnimator;


    //bullet
    [SerializeField] private int bullet = 3;
    public TextMeshProUGUI bulletText;

    //mainmenu canvas
    [SerializeField] private GameObject progressBarObject;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject restartMenuObject;

    [SerializeField] private GameObject mainMenuObject;

    private void Update()
    {
        scoreText.text = _score.ToString();//sadece texte baðlamak kaldý hata alýyorum 
        bulletText.text = _score.ToString();
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

    //bullet
    //bullet texti oyun baþladýðýnda 0 oluyor
    private void OnEnable()
    {
        EventManager.RemainingBullet += DecreaseBullet;
    }

    private void OnDisable()
    {
        EventManager.RemainingBullet -= DecreaseBullet;
    }

    public void DecreaseBullet()
    {
        bullet--;
    }

}


    