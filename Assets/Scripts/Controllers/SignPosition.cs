using UnityEngine;

namespace Control
{
    public class SignPosition
    {
        public struct Ctx
        {
            public Camera cam;
        }

        private RaycastHit _signPosition;
        private Ctx _ctx;
        public SignPosition(Ctx ctx)
        {
            _ctx = ctx;
        }
        public RaycastHit SignPositon()
        {
            return _signPosition;
        }

        public void Tick()
        {
            Ray ray = _ctx.cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _signPosition = hit;
            }
            else
                _signPosition.distance = 5000;
        }
    }
}
