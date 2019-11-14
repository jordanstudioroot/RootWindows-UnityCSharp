using UnityEngine;
using UnityEngine.UI;

public class ColumnGridFlexibleRect : GridViewRect
{
    public static GridLayoutGroup.Constraint ConstraintType {
        get {
            return GridLayoutGroup.Constraint.FixedColumnCount;
        }
    }

    protected override Layout LayoutType {
        get {
            return Layout.ColumnGrid;
        }
    }

    public static ColumnGridFlexibleRect GetRect(ViewData viewData, int constraintCount)
    {
        GameObject result = new GameObject("ColumnGridViewRect");
        ColumnGridFlexibleRect resultMono = result.AddComponent<ColumnGridFlexibleRect>();
        resultMono.ViewData = viewData;
        resultMono.BGColor = new Color(0f, 0f, 0f, 0f);
        resultMono.GridLayoutGroup.constraint = ConstraintType;
        resultMono.GridLayoutGroup.constraintCount = constraintCount;
        return resultMono;
    }

    protected override void HandleViewDataChanged(ViewData data)
    {
        //BGColor = data.ContentBGColor;
    }
}