using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: bu classin bazi kisimlarini silip kendin yaz 
public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;//platformun coll
    [SerializeField] private LayerMask layerMask; //platformun sayaca�i nesnelerin katmanlarini belirler(sadece box)

    private int totalBoxCount;//platformun �zerindeki ba�lang��taki kutu sayisi
    private int currentBoxCount;//platformun �zerinde olan �uan ki kutu sayisi 
    public Action<int> OnHittedBoxCountChange;//kalan kutu sayisi de�i�ti�inde tetiklenen event
    public Action OnBoxCountFinish;

    private void Start()
    {
        totalBoxCount = CalculateBoxCountOnPlatform(); //platformdaki hesaplanm�� kutu sayisini ba�lang��taki de�ere atar ki ba�lang��ta ka� kutu oldugu bilinebilsin
        InvokeRepeating(nameof(CheckGameEnd), 0, 2f);//method 2 saniyede bir tekrar tekrar �al���r
    }
    
    
    
    public void CheckGameEnd()//anlamadim:
    {
        var numberOfBoxOnPlatform = CalculateBoxCountOnPlatform();

        if (currentBoxCount != numberOfBoxOnPlatform)//hesaplanan sayi �nceki kutu sayisi ile farkliysa �uanki kutu sayisini g�nceller
        {
            currentBoxCount = numberOfBoxOnPlatform;
            OnHittedBoxCountChange?.Invoke(totalBoxCount - numberOfBoxOnPlatform);
        }
        
        if (numberOfBoxOnPlatform == 0)//platformun �zerinde hi� kutu kalmadiysa bu ko�ullu d�ng�ye girer
        {
            OnBoxCountFinish?.Invoke();
            Invoke(nameof(NextLevelTransition), 2f);
        }
    }

    private static void NextLevelTransition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private int CalculateBoxCountOnPlatform()//platformun �arp��ma alan� boyutlar�n� ve konumunu hesaplayarak kutu say�s� belirlenir
    {
        var colliderPosition = transform.position + collider.center;
        var numberOfBoxOnPlatform = Physics.OverlapBox(colliderPosition,  collider.size, Quaternion.identity, layerMask).Length;
        return numberOfBoxOnPlatform;
    }
}
