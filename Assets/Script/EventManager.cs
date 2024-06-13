using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Event : tanimladiðimiz delegate fonks. eventlerde kullanýyoruz
    //Delegate : deðisken tanimlar gibi fonksyion tanýmlama
    //Lambda : tek satirda basit iþlemleri olan fonks. yazmak için kullanýlýr

    public delegate void BulletDelegate();
    public static BulletDelegate RemainingBullet;//static tanýmlanmasýnýn sebebi her yerden rahatça eriþmek

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
