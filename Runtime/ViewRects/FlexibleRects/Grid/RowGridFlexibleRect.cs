using UnityEngine;
using UnityEngine.UI;

public class RowGridFlexibleRect : GridViewRect
{
    public static GridLayoutGroup.Constraint ConstraintType {
        get {
            return GridLayoutGroup.Constraint.FixedRowCount;
        }
    }

    protected override Layout LayoutType {
        get {
            return Layout.RowGrid;
        }
    }

    public static RowGridFlexibleRect GetRect(ViewData viewData, int constraintCount)
    {
        GameObject result = new GameObject();
        RowGridFlexibleRect resultMono = result.AddComponent<RowGridFlexibleRect>();
        resultMono.GridLayoutGroup.constraint = ConstraintType;
        resultMono.ConstraintCount = constraintCount;
        return resultMono;
    }

    protected override void HandleViewDataChanged(ViewData data)
    {
        BGColor = data.ContentBGColor;
    }
}