using UnityEngine;
using Pool;

public class BulletController : MonoBehaviour
{
    private Rigidbody _rb;
    private TrailRenderer _trail;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _trail = GetComponent<TrailRenderer>();
    }
    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        PoolManager.GetObject("Explosion", transform.position, Quaternion.identity);
        _trail.Clear();
    }
}
