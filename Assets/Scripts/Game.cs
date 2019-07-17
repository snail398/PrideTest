using Configuration;
using Control;
using TankSpace;
using UnityEngine;
using CameraSpace;
using GunSpace;
using Loaders;

namespace GameInit
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private TankView tankView;
        [SerializeField] private GameObject cam;
        [SerializeField] TextAsset _configData;
        [SerializeField] HUDController _hud;

        private Config _config;
        private SignPosition _signPosition;
        private Tank _tank;

        private void Awake()
        {
            _config = new ConfigLoader(_configData.text).LoadConfig();
            SignPositionerCreate();
            TankInit();
            HUDInit();
        }

        private void Update()
        {
            _signPosition.Tick();
            _tank.Tick();
        }


        private void HUDInit()
        {
            HUDController.Ctx hudCtx = new HUDController.Ctx
            {
                signHit = _signPosition.SignPositon,
                crosshairSize = _config.crosshairSize,
                canShoot = _tank.CheckCanShoot,
            };
            _hud.SetCtx(hudCtx);
        }
        private void SignPositionerCreate()
        {
            SignPosition.Ctx signCtx = new SignPosition.Ctx
            {
                cam = Camera.main,
            };
            _signPosition = new SignPosition(signCtx);
        }
      
        private void TankInit()
        {
            TankView view = Instantiate(tankView, new Vector3(0, 1, 0), Quaternion.identity);
            TankView.Ctx tankViewCtx = new TankView.Ctx
            {
                tankForwardSpeed = _config.tankForwardSpeed,
                tankBackSpeed = _config.tankBackSpeed,
                tankRotateSpeed = _config.tankRotateSpeed,
            };
            view.SetCtx(tankViewCtx);
            Tank.Ctx tankCtx = new Tank.Ctx
            {
                tankView = view,
                horizontalAngle = _config.horizontalAngle,
                reloadTime = _config.reloadTime,
                signHit = _signPosition.SignPositon,
                verticalAngle = _config.verticalAngle,
            };
            _tank = new Tank(tankCtx);
            ControlInit(view, _tank, _tank.GetGun());
            CameraInit(view);
        }

        private void ControlInit(TankView tankView,Tank tank, Gun gun)
        {
            KeyboardController control = tankView.gameObject.AddComponent<KeyboardController>() as KeyboardController;
            control.SetControl(tank, gun);
        }

        private void CameraInit(TankView tankView)
        {
            CameraController.Ctx camCtx = new CameraController.Ctx
            {
                target = tankView.gameObject,
                cameraOffset = new Vector3(0, 15, -20),
                dampTime = _config.cameraDampTime,
            };
            CameraController cameraController = cam.AddComponent<CameraController>() as CameraController;
            cameraController.SetCtx(camCtx);
        }
    }
}
