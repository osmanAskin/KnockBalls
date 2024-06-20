using System;
using Lean.Pool;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private CannonShootScenario cannonShootScenario;
    [SerializeField] private Ball prefab;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask clickLayerMask;

    public int bulletCount;
    private Ball currentBall;
    public Action<int> OnBulletCountChange;
    public Action OnBulletFinish;
    private bool onBulletFinishChecked;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        OnBulletCountChange?.Invoke(bulletCount);
        SpawnNewBall();
    }

    public void OnPointerUp(BaseEventData eventData)
    {
        if (onBulletFinishChecked) return;
        
        if(bulletCount <= 0)
        {
            onBulletFinishChecked = true;
            OnBulletFinish?.Invoke();
            return;
        }

        PointerEventData pointerEventData = eventData as PointerEventData;
        Ray ray = Camera.main.ScreenPointToRay(pointerEventData.position);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.15f, out hit, 100f, clickLayerMask, QueryTriggerInteraction.Ignore))
        {
            ShootTarget(hit.point);

            bulletCount--;
            OnBulletCountChange?.Invoke(bulletCount);
        }

        audioManager.Play(SoundType.CannonShoot);
        CameraUtils.Shake();

        cannonShootScenario.Execute();
    }

    public void ShootTarget(Vector3 raycastHitPosition)
    {
        Vector3 fromTo2D = new Vector3(raycastHitPosition.x - transform.position.x, 0, raycastHitPosition.z - transform.position.z);
        float angle = 0;
        LaunchAngle(speed, fromTo2D.magnitude, raycastHitPosition.y - transform.position.y, Physics.gravity.magnitude, out angle);
        angle *= Mathf.Rad2Deg;
        SetVelocity(currentBall, Quaternion.AngleAxis(angle, -transform.right) * fromTo2D.normalized * speed);
        currentBall = null;
        Invoke(nameof(SpawnNewBall), .1f);
    }

    // Taken from: https://github.com/IronWarrior/ProjectileShooting
    public bool LaunchAngle(float speed, float distance, float yOffset, float gravity, out float angle)
    {
        angle = 0;

        float speedSquared = speed * speed;

        float operandA = Mathf.Pow(speed, 4);
        float operandB = gravity * (gravity * (distance * distance) + (2 * yOffset * speedSquared));

        // Target is not in range
        if (operandB > operandA)
            return false;

        float root = Mathf.Sqrt(operandA - operandB);

        angle = Mathf.Atan((speedSquared - root) / (gravity * distance));

        return true;
    }

    private void SetVelocity(Ball ball, Vector3 velocity)//topun rb bilesenine yeni bir hiz degeri atiyor
    {
        ball.OnFire();
        ball.rb.AddForce(velocity, ForceMode.VelocityChange);
    }

    public void SpawnNewBall()//leanpool sistemi kullanarak yeni bir top olu�turur ve onu atilmaya hazir hale getirir
    {
        currentBall = LeanPool.Spawn(prefab,transform.position,Quaternion.identity);
        currentBall.OnSpawn();
    }
}