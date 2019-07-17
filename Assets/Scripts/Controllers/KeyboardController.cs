using TankSpace;
using UnityEngine;
using GunSpace;

namespace Control
{
    public class KeyboardController : MonoBehaviour, IControl
    {
        private Tank _tank;
        private Gun _gun;

        public void SetControl(Tank tank, Gun gun)
        {
            _tank = tank;
            _gun = gun;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _tank?.MoveForward();
            }
            if (Input.GetKey(KeyCode.S))
            {
                _tank?.MoveBackward();
            }
            if (Input.GetKey(KeyCode.A))
            {
                _tank?.RotateLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                _tank?.RotateRight();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _gun?.Shoot();
            }
        }
    }
}
