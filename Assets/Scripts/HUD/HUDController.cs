using UnityEngine;
using System;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Texture2D greenCrosshair;
    [SerializeField] private Texture2D redCrosshair;

    private Texture2D _crosshair;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;

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
        _hotSpot = new Vector2(_ctx.crosshairSize * 5, _ctx.crosshairSize * 5);
    }

    public void OnGUI()
    {
        if (_ctx.canShoot.Invoke())
            Cursor.SetCursor(greenCrosshair, _hotSpot, _cursorMode);
        else
            Cursor.SetCursor(redCrosshair, _hotSpot, _cursorMode);
        //Vector3 mousePos = Camera.main.WorldToScreenPoint(_ctx.signHit.Invoke().point);
        //GUI.DrawTexture(new Rect(mousePos.x - _ctx.crosshairSize / 2, Screen.height - mousePos.y - _ctx.crosshairSize / 2, _ctx.crosshairSize, _ctx.crosshairSize), _crosshair);
    }
}
