using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button tapToButton; 

    void Start()
    {
        tapToButton = GetComponent<Button>();
        tapToButton.onClick.AddListener(StartButton);
    }
    
    public void StartButton() 
    {
        //gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
