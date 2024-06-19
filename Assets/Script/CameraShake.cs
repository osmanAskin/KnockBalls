using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance; 

    private void Awake() => instance = this;

    private void OnShake(float duration,float strenght) 
    {
        transform.DOShakePosition(duration, strenght);
        transform.DOShakeRotation(duration, strenght);        
    }

    public static void Shake(float duration, float strenght) => instance.OnShake(duration, strenght);

    //burayi scale yap
    private void OnScale(int x, int y)
    {
        transform.DOShakeScale(x, y);
    }

    public static void Scale(int x, int y) => instance.OnScale(x,y);


}
