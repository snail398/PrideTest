using System;
using UnityEngine;

namespace TankSpace
{
    public class TankView : MonoBehaviour
    {
        [SerializeField] private Transform shootingPosition;
        [SerializeField] private GunView gunView;

        public struct Ctx
        {
            public float tankForwardSpeed;
            public float tankBackSpeed;
            public float tankRotateSpeed;
        }

        private Ctx _ctx;
        public void SetCtx(Ctx ctx)
        {
            CheckCtx(ctx);
            _ctx = ctx;
        }
        public void MoveForward()
        {
            transform.position += transform.right * Time.deltaTime * _ctx.tankForwardSpeed;
        }

        public void MoveBackward()
        {
            transform.position -= transform.right * Time.deltaTime * _ctx.tankBackSpeed;
        }

        public void RotateLeft()
        {
            transform.Rotate(transform.up, -1 * _ctx.tankRotateSpeed);
        }

        public void RotateRight()
        {
            transform.Rotate(transform.up, _ctx.tankRotateSpeed);
        }
        
        private void CheckCtx(Ctx ctx)
        {
            if (ctx.tankForwardSpeed == 0)
                Debug.Log("Tank cant move forward. Forward speed is zero");
            if (ctx.tankBackSpeed == 0)
                Debug.Log("Tank cant move backward. Backward speed is zero");
            if (ctx.tankForwardSpeed == 0)
                Debug.Log("Tank cant rotate. Rotation speed is zero");
        }

        public Transform GetShootingPosition()
        {
            return shootingPosition;
        }

        public GunView GetGunView()
        {
            return gunView;
        }
    }
}
