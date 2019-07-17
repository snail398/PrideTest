using UnityEngine;
using Pool;
using System;

namespace GunSpace
{
    public class Gun
    {
        public struct Ctx
        {
            public float reloadTime;
            public Func<RaycastHit> signHit;
            public int horizontalAngle;
            public int verticalAngle;
            public Transform shootingPosition;
            public GunView gunView;
        }

        private Ctx _ctx;
        private bool _canShoot;
        public bool CanShoot
        {
            get => _canShoot;
        }

        public Gun(Ctx ctx)
        {
            _ctx = ctx;
        }

        public void Tick()
        {
            RaycastHit hit = _ctx.signHit.Invoke();
            CheckCanShoot(hit);
        }

        public void CheckCanShoot(RaycastHit hit)
        {
            Vector3 sign = VectorToPlane((hit.point - _ctx.shootingPosition.position).normalized);
            if (Vector3.Angle(VectorToPlane(_ctx.shootingPosition.right),sign) > _ctx.horizontalAngle / 2)
            {
                _canShoot = false;
                return;
            }
            _canShoot = true;
        }

        public void Shoot()
        {
            if (!CanShoot) return;
            RaycastHit hit = _ctx.signHit.Invoke();
            PoolManager.GetObject("Bullet", _ctx.shootingPosition.position, Quaternion.identity).GetComponent<Rigidbody>()
                .AddForce(((hit.point - _ctx.shootingPosition.position).normalized + Vector3.up * (hit.point - _ctx.shootingPosition.position).magnitude * 0.078f) * 400);
            _ctx.gunView.Shoot();
        }

        private Vector3 VectorToPlane(Vector3 source)
        {
            return new Vector3(source.x, 0, source.z);
        }
    }
}
