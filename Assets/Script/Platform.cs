using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: bu classin bazi kisimlarini silip kendin yaz 
public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private LayerMask layerMask;

    private int totalBoxCount;
    private int currentBoxCount;
    public Action<int> OnBoxCountChange;

    private void Start()
    {
        totalBoxCount = CalculateBoxCountOnPlatform();
        InvokeRepeating(nameof(CheckGameEnd), 0, 2f);
    }
    
    
    
    public void CheckGameEnd()
    {
        var numberOfBoxOnPlatform = CalculateBoxCountOnPlatform();

        if (currentBoxCount != numberOfBoxOnPlatform)
        {
            currentBoxCount = numberOfBoxOnPlatform;
            OnBoxCountChange?.Invoke(totalBoxCount - numberOfBoxOnPlatform);
        }
        
        if (numberOfBoxOnPlatform == 0)
        {
            Debug.Log("NextLevel");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private int CalculateBoxCountOnPlatform()
    {
        var colliderPosition = transform.position + collider.center;
        var numberOfBoxOnPlatform = Physics.OverlapBox(colliderPosition,  collider.size, Quaternion.identity, layerMask).Length;
        return numberOfBoxOnPlatform;
    }
}
