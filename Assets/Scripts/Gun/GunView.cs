using System;
using UnityEngine;

public class GunView : MonoBehaviour
{
    public struct Ctx
    {
        public Func<RaycastHit> signHit;
        public Transform tankBody;
        public int horizontalAngle;
        public int verticalAngle;
    }

    private Ctx _ctx;

    public void SetCtx(Ctx ctx)
    {
        _ctx = ctx;
    }

    public void Shoot()
    {
        //Эффект выстрела
    }

    private void Update()
    {
        Vector3 sign = VectorToPlane((_ctx.signHit.Invoke().point - _ctx.tankBody.position).normalized, _ctx.tankBody.position);
        float bodyAngle =  Vector3.Angle(_ctx.tankBody.right, sign);
        float towerAngle =  -1 * Mathf.Sign(Vector3.Dot(Vector3.forward, sign)) * Vector3.Angle(Vector3.right, sign);
        float vertTowerAngle = (_ctx.signHit.Invoke().point - transform.position).magnitude * 2.2f;
        if (bodyAngle < _ctx.horizontalAngle / 2)
            transform.rotation = Quaternion.Euler(0, towerAngle, vertTowerAngle);
    }

    private Vector3 VectorToPlane(Vector3 source, Vector3 plane)
    {
        return new Vector3(source.x, 0, source.z);
    }
}
