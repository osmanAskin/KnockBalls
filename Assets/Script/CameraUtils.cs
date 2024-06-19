using DG.Tweening;
using UnityEngine;

public static class CameraUtils
{
    public static void Shake()
    {
        Camera.main.DOShakePosition(.2f, .25f, 15);
    }
}
