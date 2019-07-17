using UnityEngine;
using GunSpace;
using System;

namespace TankSpace
{
    public class Tank
    {
        public struct Ctx
        {
            public TankView tankView;
            public float reloadTime;
            public Func<RaycastHit> signHit;
            public int horizontalAngle;
            public int verticalAngle;
        }

        private Ctx _ctx;
        private Gun _gun;

        public Tank(Ctx ctx)
        {
            _ctx = ctx;
            GunCreate();
        }

        private void GunCreate()
        {
            GunView.Ctx gunViewCtx = new GunView.Ctx
            {
                signHit = _ctx.signHit,
                tankBody = _ctx.tankView.transform,
                horizontalAngle = _ctx.horizontalAngle,
                verticalAngle = _ctx.verticalAngle,
            };
            _ctx.tankView.GetGunView().SetCtx(gunViewCtx);
            Gun.Ctx gunCtx = new Gun.Ctx
            {
                reloadTime = _ctx.reloadTime,
                horizontalAngle = _ctx.horizontalAngle,
                verticalAngle = _ctx.verticalAngle,
                signHit = _ctx.signHit,
                shootingPosition = _ctx.tankView.GetShootingPosition(),
                gunView = _ctx.tankView.GetGunView(),
            };
            _gun = new Gun(gunCtx);
        }

        public bool CheckCanShoot()
        {
            return _gun.CanShoot;
        }

        public Gun GetGun()
        {
            return _gun;
        }

        public void MoveForward()
        {
            _ctx.tankView.MoveForward();
        }

        public void MoveBackward()
        {
            _ctx.tankView.MoveBackward();
        }

        public void RotateLeft()
        {
            _ctx.tankView.RotateLeft();
        }

        public void RotateRight()
        {
            _ctx.tankView.RotateRight();
        }

        public void Tick()
        {
            _gun.Tick();
        }
    }
}
