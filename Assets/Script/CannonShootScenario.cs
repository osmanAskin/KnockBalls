using UnityEngine;

public class CannonShootScenario : MonoBehaviour
{
    [SerializeField] private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void Execute()
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



