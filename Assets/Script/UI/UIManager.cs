using UnityEngine;

// TODO: ui ile ilgili genel seyler burda olmali
public class UIManager : MonoBehaviour
{
    //first scene settings 
    public Animator LayoutAnimator;

    public void LayoutSettingsOpen() 
    {
        LayoutAnimator.SetTrigger("slide_in");
    }

    public void LayoutSettingsClose()
    {
        LayoutAnimator.SetTrigger("slide_out");
    }
}
