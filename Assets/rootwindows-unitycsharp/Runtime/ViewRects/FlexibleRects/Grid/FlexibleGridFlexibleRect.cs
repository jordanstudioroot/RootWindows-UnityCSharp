using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridFlexibleRect : GridViewRect
{
    public static GridLayoutGroup.Constraint ConstraintType {
        get {
            return GridLayoutGroup.Constraint.Flexible;
        }
    }
    protected override Layout LayoutType {
        get {
            return Layout.FlexibleGrid;
        }
    }

    public static FlexibleGridFlexibleRect GetRect(ViewData viewData, int constraintCount)
    {
        GameObject result = new GameObject("Flexible Grid View");
        FlexibleGridFlexibleRect resultMono = result.AddComponent<FlexibleGridFlexibleRect>();
        resultMono.ViewData = viewData;
        resultMono.BGColor = new Color(0f, 0f, 0f, 0f);
        resultMono.GridLayoutGroup.constraint = ConstraintType;
        resultMono.GridLayoutGroup.constraintCount = constraintCount;
        return resultMono;
    }

    protected override void HandleViewDataChanged(ViewData data)
    {
        BGColor = data.ContentBGColor;
    }
}