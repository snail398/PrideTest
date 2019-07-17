using System.Collections;
using System.Collections.Generic;
using TankSpace;
using UnityEngine;

namespace CameraSpace
{
    public class CameraController : MonoBehaviour
    {
        public struct Ctx
        {
            public Vector3 cameraOffset;
            public float dampTime;
            public GameObject target;
        }

        private Ctx _ctx;
        private Vector3 _moveVelocity;
                    
        public void SetCtx(Ctx ctx)
        {
            _ctx = ctx;
        }

        private void Update()
        {
            transform.position = Vector3.SmoothDamp(transform.position, FindCameraPosition(), ref _moveVelocity, _ctx.dampTime);
        }

        private Vector3 FindCameraPosition()
        {
            return _ctx.target.transform.position + _ctx.cameraOffset;
        }
    }
}
