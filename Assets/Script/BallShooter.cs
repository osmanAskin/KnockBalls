using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    [SerializeField] Ball prefab;
    [SerializeField] private float speed;
    [SerializeField] int bullet = 3;
    public TextMeshProUGUI BulletText;

    private Rigidbody _currentBallRb;

    private void Start()
    {
        SpawnNewBall();
    }

    public void OnPointerUp(BaseEventData eventData)
    {
        // 1 saniye icinde yeni ball yaratana kadar tekrar ates etmene izin vermiyorum
        if (_currentBallRb == null) return;
        
        PointerEventData pointerEventData = eventData as PointerEventData;
        Ray ray = Camera.main.ScreenPointToRay(pointerEventData.position);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.15f, out hit, 100f, 1, QueryTriggerInteraction.Ignore)) 
        {
            ShootTarget(hit.point);


            //bullet
            bullet--;
            BulletText.text = bullet.ToString();
            Debug.Log(bullet);

            if(bullet <= 0) 
            {
                BulletText.text = ("Failed!");
                Debug.Log("Failed!");
                //top hakký bitince topu spawnlanmasini nasil engelleyeceðim
            }
        }
    }
    
    public void ShootTarget(Vector3 raycastHitPosition)
    {
        Vector3 fromTo2D = new Vector3(raycastHitPosition.x - transform.position.x, 0, raycastHitPosition.z - transform.position.z);
        float angle = 0;
        LaunchAngle(speed, fromTo2D.magnitude, raycastHitPosition.y - transform.position.y, Physics.gravity.magnitude, out angle);
        angle *= Mathf.Rad2Deg;
        SetVelocity(_currentBallRb, Quaternion.AngleAxis(angle, -transform.right) * fromTo2D.normalized * speed);
        _currentBallRb = null;
        Invoke(nameof(SpawnNewBall), 1f);
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
    
    public void SetVelocity(Rigidbody rb, Vector3 velocity)
    {
        rb.isKinematic = false;
        rb.AddForce(velocity, ForceMode.VelocityChange);
    }

    public void SpawnNewBall()
    {

        // bunu getcomponent ile yapma, ball scriptinin icinde rigidbody olsun ordan ulas//tamam kardesim
        _currentBallRb = LeanPool.Spawn<Ball>(prefab,transform.position,Quaternion.identity).rb;
    }
}