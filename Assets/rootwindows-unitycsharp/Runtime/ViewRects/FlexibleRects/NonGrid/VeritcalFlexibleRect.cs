using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class VerticalFlexibleRect : FlexibleViewRect
{
    public static VerticalFlexibleRect GetRect(ViewData viewData) {
        GameObject result = new GameObject("Vertical View Rect");
        VerticalFlexibleRect resultMono = result.AddComponent<VerticalFlexibleRect>();
        resultMono.ViewData = viewData;
        resultMono.BGColor = new Color(0f, 0f, 0f, 0f);
        return resultMono;
    }

    public override void Refresh()
    {
        foreach(ViewRect rect in ViewRectChildren) {
            rect.SizeDelta = GetCellSize(SizeDelta, LayoutType, AllChildren.Length);
        }
    }

    protected override Layout LayoutType { 
        get {
            return Layout.Vertical;
        }
    }

    protected override void HandleViewDataChanged(ViewData data) {
        BGColor = data.ContentBGColor;
    }
}