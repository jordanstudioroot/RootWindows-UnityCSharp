using UnityEngine;
using UnityEngine.EventSystems;

public class MoveHandleRect : ViewRect, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public bool locked;
    public static MoveHandleRect GetRect(ViewData viewData) {
        GameObject resultObj  = new GameObject("Subject Bar");
        MoveHandleRect resultMono = resultObj.AddComponent<MoveHandleRect>();
        resultMono.ViewData = viewData;
        return resultMono;
    }

    public void OnPointerEnter(PointerEventData pData) {
        if (!locked) {
            Texture2D moveTex = Resources.Load("MouseMove") as Texture2D;
            Vector2 pointerPos = new Vector2(5f, 15f);
            Cursor.SetCursor(moveTex, pointerPos, CursorMode.Auto);
        }
    }

    public void OnPointerExit(PointerEventData pData) {
        if (!locked) {
            Cursor.SetCursor(null, Vector3.zero, CursorMode.Auto);
        }
    }

    public void OnDrag(PointerEventData pData) {
        if (!locked && pData.IsOnScreen()) {
            ViewData.PosX = pData.position.x - (transform.position.x - ViewData.PosX);
            ViewData.PosY = pData.position.y - (transform.position.y - ViewData.PosY);
        }
    }

    protected override void HandleViewDataChanged(ViewData data) {
        BGColor = data.MoveHandleBGColor;
        RectTransform.anchorMin = new Vector2(.5f, data.PercentSubjectCenterY);
        RectTransform.anchorMax = new Vector2(.5f, data.PercentSubjectCenterY);
        RectTransform.sizeDelta = new Vector2(
            data.TotalWidth - (data.BorderThickness * 2f), 
            ViewData.MoveHandleHeight
        );

        RectTransform.sizeDelta = 
            new Vector2(data.TotalWidth - (2 * data.BorderThickness), ViewData.MoveHandleHeight);
    }
}
