using System;
using Lean.Pool;
using UnityEngine;
using UnityEngine.EventSystems;

//TODO: ui kisimlarini burdan kaldir, GameManager'dan oyun bitti fonksiyonunu cagir ve oranin icinde oyunu bitir ui degisiklerini de 
public class BallShooter : MonoBehaviour
{
    [SerializeField] Ball prefab;//eri�im belirleyicisi default de�er olarak private alir
    [SerializeField] private float speed;
    [SerializeField] private LayerMask clickLayerMask;//t�klanabilir laylerlar
    
    public int bulletCount;
    private Rigidbody currentBallRb;
    public Action<int> OnBulletCountChange;//mermi say�s�ndaki de�i�iklikleri bildiren event
    public Action OnBulletFinish;

    private void Start()
    {
        OnBulletCountChange?.Invoke(bulletCount);
        SpawnNewBall();//olan topu tekrar spawnliyo
    }
    
    public void OnPointerUp(BaseEventData eventData)//ekrana t�kland���nda tetiklenir
    {
        //TODO: MERMI YOKSA OYUN BITTI FAIL ET ADAMI, BU FAILIDA ACTION ILE YAP OnBulletFinish yap ve buna fail menuden subscribe ol
        if (bulletCount <= 0) 
        {
            return;//mermi sayisi s�f�rdan k�c�k veya az ise bos return d�nd�r�r
        } 

        if (currentBallRb == null) return; //at�lmaya hazir top yoksa da bos return d�nd�r�r yani foknsiyondan c�kar
        
        PointerEventData pointerEventData = eventData as PointerEventData;
        Ray ray = Camera.main.ScreenPointToRay(pointerEventData.position);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.15f, out hit, 100f, clickLayerMask, QueryTriggerInteraction.Ignore))//k�saca ���n g�nderiyor ve �arpan yerin konumunu aliyor
        {
            ShootTarget(hit.point);
            
            bulletCount--;
            OnBulletCountChange?.Invoke(bulletCount);   
            if (bulletCount == 0)
            {
                OnBulletFinish?.Invoke();
            }
        }
    }
    

    
    public void ShootTarget(Vector3 raycastHitPosition)//matematiksel i�lmler
    {
        Vector3 fromTo2D = new Vector3(raycastHitPosition.x - transform.position.x, 0, raycastHitPosition.z - transform.position.z);
        float angle = 0;
        LaunchAngle(speed, fromTo2D.magnitude, raycastHitPosition.y - transform.position.y, Physics.gravity.magnitude, out angle);
        angle *= Mathf.Rad2Deg;
        SetVelocity(currentBallRb, Quaternion.AngleAxis(angle, -transform.right) * fromTo2D.normalized * speed);
        currentBallRb = null;
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
    
    public void SetVelocity(Rigidbody rb, Vector3 velocity)//topun rb bile�enine yeni bir h�z de�eri atiyor
    {
        rb.isKinematic = false;
        rb.AddForce(velocity, ForceMode.VelocityChange);
    }

    public void SpawnNewBall()//leanpool sistemi kullanarak yeni bir top olu�turur ve onu atilmaya hazir hale getirir
    {
        currentBallRb = LeanPool.Spawn(prefab,transform.position,Quaternion.identity).rb;
        currentBallRb.isKinematic = true;
    }
}