using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        InvokeRepeating(nameof(CheckGameEnd), 0, 2f);
    }

    // ai'a kesin sor
    public void CheckGameEnd()
    {
        var colliderPosition = transform.position + collider.center; 
        var numberOfResults = Physics.OverlapBox(colliderPosition,  collider.size, Quaternion.identity, layerMask).Length;
        
        if (numberOfResults == 0)
        {
            Debug.Log("NextLevel");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
