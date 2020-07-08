using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class HorizontalFlexibleRect : FlexibleViewRect {
    public static HorizontalFlexibleRect GetRect(ViewData viewData) {
        GameObject result = new GameObject("Horizontal View Rect");
        HorizontalFlexibleRect resultMono = result.AddComponent<HorizontalFlexibleRect>();
        resultMono.ViewData = viewData;
        resultMono.BGColor = new Color(0f, 0f, 0f, 0f);
        return resultMono;
    } 

    public override void Refresh()
    {
        foreach (ViewRect rect in ViewRectChildren) {
            rect.SizeDelta = GetCellSize(SizeDelta, LayoutType, AllChildren.Length);
        }
    }

    protected override Layout LayoutType {
        get {
            return Layout.Horizontal;
        }
    }

    protected override void HandleViewDataChanged(ViewData data)
    { 
        BGColor = data.ContentBGColor;
    }    
}