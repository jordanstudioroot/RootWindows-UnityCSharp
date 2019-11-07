using UnityEngine;

public class BackgroundRect : ViewRect
{
    protected override void HandleViewDataChanged(ViewData data) {
        BGColor = data.MoveHandleBGColor;
        RectTransform.sizeDelta = new Vector2(data.TotalWidth, data.TotalHeight);
        RectTransform.position = new Vector2(data.PosX, data.PosY);
    }
}
