using UnityEngine;

public class CannonEffects : MonoBehaviour
{
    [SerializeField] private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void AnimatorActivate()
    {
        if (mAnimator != null)
        {
            mAnimator.SetTrigger("TrOpen");
        }

        else
        {
            Debug.LogError("Animator not assigned!");
        }
    }
}



