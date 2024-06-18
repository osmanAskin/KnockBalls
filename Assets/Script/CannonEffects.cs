using UnityEngine;

public class CannonEffects : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void CannonShootAnimation()
    {
        if (animator != null)
        {
            animator.Play("Cannon");
            Debug.Log("calisti");
        }
        else
        {
            Debug.LogError("Animator bileþeni atanmadý!");
        }
    }
}



