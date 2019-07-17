using UnityEngine;
using Pool;

public class BulletController : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();    
    }
    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        PoolManager.GetObject("Explosion", transform.position, Quaternion.identity);
    }
}
