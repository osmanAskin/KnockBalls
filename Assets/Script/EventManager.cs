using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Event : tanimladi�imiz delegate fonks. eventlerde kullan�yoruz
    //Delegate : de�isken tanimlar gibi fonksyion tan�mlama
    //Lambda : tek satirda basit i�lemleri olan fonks. yazmak i�in kullan�l�r

    public delegate void BulletDelegate();
    public static BulletDelegate RemainingBullet;//static tan�mlanmas�n�n sebebi her yerden rahat�a eri�mek

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if(RemainingBullet != null) 
            {
                RemainingBullet();
            }
        }
    }
}
