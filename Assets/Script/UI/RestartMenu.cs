using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    private bool isPaused;

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
