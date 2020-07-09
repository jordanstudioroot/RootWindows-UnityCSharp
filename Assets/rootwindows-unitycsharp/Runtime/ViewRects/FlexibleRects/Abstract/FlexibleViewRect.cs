using UnityEngine;
using UnityEngine.UI;
using RootUtils;
using RootExtensions;

[RequireComponent(typeof(LayoutElement))]
public abstract class FlexibleViewRect : ViewRect
{
// FIELDS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// CONSTRUCTORS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// DESTRUCTORS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// DELEGATES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// EVENTS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// ENUMS

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    protected enum Layout {
        Horizontal,
        Vertical,
        ColumnGrid,
        RowGrid,
        FlexibleGrid
    }

// INTERFACES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// PROPERTIES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    protected FlexibleViewRect ParentFlexibleViewRect {
        get {
            if (transform.parent && transform.parent.GetComponent<FlexibleViewRect>()) {
                return transform.parent.GetComponent<FlexibleViewRect>();
            }

            return null;
        }
    }

    protected FlexibleViewRect[] ChildFlexibleViewRects {
        get {
            return this.GetComponentsInDirectChildren<FlexibleViewRect>();
        }
    }

    protected RectTransform[] Leaves {
        get {
            return 
                this.GetComponentsInDirectChildrenExcept
                    <FlexibleViewRect, RectTransform>();
        }
    }
    
    protected abstract Layout LayoutType { get; }
    
    protected Layout ParentLayoutType {
        get {
            return ParentFlexibleViewRect.LayoutType;
        }
    }

// INDEXERS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// METHODS ~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    public abstract void Refresh();

    protected Vector2 GetCellSize(
        Vector2 bounds,
        Layout gridLayout,
        int cells,
        int constraintCount = -1
    ) {
        if (cells == 1) {
            return new Vector2(bounds.x, bounds.y);
        }

        int adjustedCells = cells % 2 == 0 ? cells : cells + 1;

        switch (gridLayout) {
            case Layout.Horizontal:
                return new Vector2(
                    bounds.x,
                    bounds.y / cells
                );
            case Layout.Vertical:
                return new Vector2(
                    bounds.x / cells,
                    bounds.y
                );
            case Layout.ColumnGrid:
                return new Vector2 (
                    bounds.x / constraintCount,
                    bounds.y * ((float)constraintCount / (float)adjustedCells)
                );
            case Layout.RowGrid:
                return new Vector2(
                    bounds.x * ((float)constraintCount / (float)adjustedCells),
                    bounds.y / constraintCount
                );
            case Layout.FlexibleGrid:
                return new Vector2(
                    bounds.x / (adjustedCells / 2),
                    bounds.y / (adjustedCells / 2)
                );
            default:
                throw new System.Exception("Unsupported layout");
        }
    }

// STRUCTS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// CLASSES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
}