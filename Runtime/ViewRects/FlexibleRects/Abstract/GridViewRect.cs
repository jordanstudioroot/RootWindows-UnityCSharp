using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public abstract class GridViewRect : FlexibleViewRect {
    private GridLayoutGroup _gridLayoutGroup;
    public GridLayoutGroup GridLayoutGroup {
        get {
            if (_gridLayoutGroup)
                return _gridLayoutGroup;
            throw new System.Exception("GridLayoutGroup has not been initialized " +
                " on " + name);
        }
    }
    private new void Awake() {
        base.Awake();
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public int ConstraintCount {
        get {
            return _gridLayoutGroup.constraintCount;
        }
        protected set {
            _gridLayoutGroup.constraintCount = value;
        }
    }

    public Vector2 CellSize {
        set {
            _gridLayoutGroup.cellSize = value;
        }
    }
    
    public override void Refresh() {
        Vector2 contentSizeDelta = new Vector2(
            ViewData.ContentWidth,
            ViewData.ContentHeight
        );

        SizeDelta = contentSizeDelta;

        CellSize = GetCellSize(
            SizeDelta,
            LayoutType,
            AllChildren.Length,
            ConstraintCount
        );
    }
}