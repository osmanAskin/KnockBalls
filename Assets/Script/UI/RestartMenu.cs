using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    public Button restartButton;
    public bool isPaused = false;

    public void FreezeScene() 
    {
        if (isPaused) 
        {
            Time.timeScale = 1.0f;
            isPaused = false;
        }
        else if(!isPaused) 
        {
            Time.timeScale = 0.0f;
            isPaused = true;

        }
    }
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
