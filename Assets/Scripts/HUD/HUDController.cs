using UnityEngine;
using System;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Texture2D greenCrosshair;
    [SerializeField] private Texture2D redCrosshair;

    private Texture2D crosshair;

    public struct Ctx
    {
        public Func<RaycastHit> signHit;
        public Func<bool> canShoot;
        public int crosshairSize;
    };

    private Ctx _ctx;

    public void SetCtx(Ctx ctx)
    {
        _ctx = ctx;
    }

    public void OnGUI()
    {
        if (_ctx.canShoot.Invoke())
            crosshair = greenCrosshair;
        else
            crosshair = redCrosshair;
        Vector3 mousePos = Camera.main.WorldToScreenPoint(_ctx.signHit.Invoke().point);
        GUI.DrawTexture(new Rect(mousePos.x - _ctx.crosshairSize / 2, Screen.height - mousePos.y - _ctx.crosshairSize / 2, _ctx.crosshairSize, _ctx.crosshairSize), crosshair);
    }
}
