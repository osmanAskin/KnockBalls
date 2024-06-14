using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: bu classin bazi kisimlarini silip kendin yaz 
public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;//platformun coll
    [SerializeField] private LayerMask layerMask; //platformun sayacaði nesnelerin katmanlarini belirler(sadece box)

    private int totalBoxCount;//platformun üzerindeki baþlangýçtaki kutu sayisi
    private int currentBoxCount;//platformun üzerinde olan þuan ki kutu sayisi 
    public Action<int> OnBoxCountChange;//kalan kutu sayisi deðiþtiðinde tetiklenen event

    //winText
    UIManager UImanager;

    private void Start()
    {
        UImanager = FindObjectOfType<UIManager>();

        totalBoxCount = CalculateBoxCountOnPlatform(); //platformdaki hesaplanmýþ kutu sayisini baþlangýçtaki deðere atar ki baþlangýçta kaç kutu oldugu bilinebilsin
        InvokeRepeating(nameof(CheckGameEnd), 0, 2f);//method 2 saniyede bir tekrar tekrar çalýþýr
    }
    
    
    
    public void CheckGameEnd()//anlamadim:
    {
        var numberOfBoxOnPlatform = CalculateBoxCountOnPlatform();

        if (currentBoxCount != numberOfBoxOnPlatform)//hesaplanan sayi önceki kutu sayisi ile farkliysa þuanki kutu sayisini günceller
        {
            currentBoxCount = numberOfBoxOnPlatform;
            OnBoxCountChange?.Invoke(totalBoxCount - numberOfBoxOnPlatform);
        }
        
        if (numberOfBoxOnPlatform == 0)//platformun üzerinde hiç kutu kalmadiysa bu koþullu döngüye girer
        {
            UImanager.WinTextWrite();

            Debug.Log("NextLevel");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private int CalculateBoxCountOnPlatform()//platformun çarpýþma alaný boyutlarýný ve konumunu hesaplayarak kutu sayýsý belirlenir
    {
        var colliderPosition = transform.position + collider.center;
        var numberOfBoxOnPlatform = Physics.OverlapBox(colliderPosition,  collider.size, Quaternion.identity, layerMask).Length;
        return numberOfBoxOnPlatform;
    }
}
