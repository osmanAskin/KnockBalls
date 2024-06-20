using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private LayerMask layerMask; 

    private int totalBoxCount;
    private int currentBoxCount;
    public Action<int> OnHittedBoxCountChange;
    public Action OnBoxCountFinish;

    BallShooter ballShooter;

    private void Start()
    {
        totalBoxCount = CalculateBoxCountOnPlatform();
        InvokeRepeating(nameof(UpdateBoxCount), 0, 1f); 
    }

    public void UpdateBoxCount() 
    {
        var numberOfBoxOnPlatform = CalculateBoxCountOnPlatform();

        if (currentBoxCount != numberOfBoxOnPlatform) 
        {
            currentBoxCount = numberOfBoxOnPlatform;
            OnHittedBoxCountChange?.Invoke(totalBoxCount - numberOfBoxOnPlatform);
        }

        if (numberOfBoxOnPlatform == 0) 
        {
            OnBoxCountFinish?.Invoke();
        }
    }

    public int CalculateBoxCountOnPlatform() 
    {
        var colliderPosition = transform.position + collider.center;
        var numberOfBoxOnPlatform = Physics.OverlapBox(colliderPosition, collider.size, Quaternion.identity, layerMask).Length;
        return numberOfBoxOnPlatform;
    }
}
