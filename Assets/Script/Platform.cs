using DG.Tweening;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: bu classin bazi kisimlarini silip kendin yaz 
public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;//platformun coll
    [SerializeField] private LayerMask layerMask; //platformun sayaca�i nesnelerin katmanlarini belirler(sadece box)/

    private int totalBoxCount;//platformun �zerindeki ba�lang��taki kutu sayisi
    private int currentBoxCount;//platformun �zerinde olan �uan ki kutu sayisi 
    public Action<int> OnHittedBoxCountChange;//kalan kutu sayisi de�i�ti�inde tetiklenen event
    public Action OnBoxCountFinish;

    private void Start()
    {
        totalBoxCount = CalculateBoxCountOnPlatform();//oyun basladiginda kac kutu var
        InvokeRepeating(nameof(CheckGameEnd), 0, 2f);//2saniyede bir kac kutu olduguna bakar 
    }

    public void CheckGameEnd() 
    {
        var numberOfBoxOnPlatform = CalculateBoxCountOnPlatform();

        if (currentBoxCount != numberOfBoxOnPlatform) 
        {
            currentBoxCount = numberOfBoxOnPlatform;//current ile platformdaki sayi esit degilse sayilari esitler
            OnHittedBoxCountChange?.Invoke(totalBoxCount - numberOfBoxOnPlatform);//degisiklikleri hesaplar ve OnHittedBoxCountChange atar
        }

        if (numberOfBoxOnPlatform == 0) 
        {
            OnBoxCountFinish?.Invoke();//platformda kutu kalmadiysa OnBoxCountFinish actionunu cagir(win ekrani)
            Invoke(nameof(NextLevelTransition),2f); 
                
        }
    }

    private void NextLevelTransition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private int CalculateBoxCountOnPlatform()//objeler platformda mi hesaplayan mekanizma 
    {
        var colliderPosition = transform.position + collider.center;
        var numberOfBoxOnPlatform = Physics.OverlapBox(colliderPosition, collider.size, Quaternion.identity, layerMask).Length;
        return numberOfBoxOnPlatform;
    }


}
