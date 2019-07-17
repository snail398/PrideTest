using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private float _lifeTime = 2;
    private float _tempTime;

    private void OnEnable()
    {
        _tempTime = 0;
    }
    private void Update()
    {
        _tempTime += Time.deltaTime;
        if (_tempTime > _lifeTime)
            gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}
