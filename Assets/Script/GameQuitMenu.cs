using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameQuitMenu : MonoBehaviour
{
    public Button YesQuitButton;

    public void QuitButton() 
    {
        SceneManager.LoadScene(0);
    }
}
