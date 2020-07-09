using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using RootExtensions;

public class ResizeHandleRect : ViewRect, IDragHandler, IPointerEnterHandler, IPointerExitHandler {
// FIELDS ~~~~~~~~~~
    
// ~ Static
    
// ~~ public
    
// ~~ private
    private readonly Vector2 POINTER_OFFSET = new Vector2(5f, 15f);
    private static readonly Dictionary<CardinalDirections, float[]> NorthSouthResizeSigns = new Dictionary<CardinalDirections, float[]> {
        {CardinalDirections.North, new float[] {1f, -1f}},
        {CardinalDirections.Northeast, new float[]{1f, -1f}},
        {CardinalDirections.East, new float[]{0f, 0f}},
        {CardinalDirections.Southeast, new float[]{-1f, 1f}},
        {CardinalDirections.South, new float[]{-1f, 1f}},
        {CardinalDirections.Southwest, new float[]{-1f, 1f}},
        {CardinalDirections.West, new float[]{0f, 0f}},
        {CardinalDirections.Northwest, new float[]{1f, -1f}}
    };

    private static readonly Dictionary<CardinalDirections, float[]> EastWestResizeSigns = new Dictionary<CardinalDirections, float[]> {
        {CardinalDirections.North, new float[] {0f, 0f}},
        {CardinalDirections.Northeast, new float[]{1f, -1f}},
        {CardinalDirections.East, new float[]{1f, -1f}},
        {CardinalDirections.Southeast, new float[]{1f, -1f}},
        {CardinalDirections.South, new float[]{0f, 0f}},
        {CardinalDirections.Southwest, new float[]{-1f, 1f}},
        {CardinalDirections.West, new float[]{-1f, 1f}},
        {CardinalDirections.Northwest, new float[]{-1f, 1f}}
    };

    private static readonly Dictionary<CardinalDirections, float[]> NorthSouthPosSigns = new Dictionary<CardinalDirections, float[]> {
        {CardinalDirections.North, new float[] {1f, -1f}},
        {CardinalDirections.Northeast, new float[] {1f, -1f}},
        {CardinalDirections.East, new float[] {0f, 0f}},
        {CardinalDirections.Southeast, new float[] {1f, -1f}},
        {CardinalDirections.South, new float[] {1f, -1f}},
        {CardinalDirections.Southwest, new float[] {1f, -1f}},
        {CardinalDirections.West, new float[] {0f, 0f}},
        {CardinalDirections.Northwest, new float[] {1f, -1f}}
    };

    private static readonly Dictionary<CardinalDirections, float[]> EastWestPosSigns = new Dictionary<CardinalDirections, float[]> {
        {CardinalDirections.North, new float[] {0f, 0f}},
        {CardinalDirections.Northeast, new float[] {1f, -1f}},
        {CardinalDirections.East, new float[] {1f, -1f}},
        {CardinalDirections.Southeast, new float[] {1f, -1f}},
        {CardinalDirections.South, new float[] {0f, 0f}},
        {CardinalDirections.Southwest, new float[] {1f, -1f}},
        {CardinalDirections.West, new float[] {1f, -1f}},
        {CardinalDirections.Northwest, new float[] {1f, -1f}}
    };

    private static Dictionary<CardinalDirections, Texture2D> Icons = new Dictionary<CardinalDirections, Texture2D> {
        {CardinalDirections.North, Resources.Load<Texture2D>("MouseVertResize")},
        {CardinalDirections.Northeast, Resources.Load<Texture2D>("MouseDiagRightResize")},
        {CardinalDirections.East, Resources.Load<Texture2D>("MouseHorzResize")},
        {CardinalDirections.Southeast, Resources.Load<Texture2D>("MouseDiagLeftResize")},
        {CardinalDirections.South, Resources.Load<Texture2D>("MouseVertResize")},
        {CardinalDirections.Southwest, Resources.Load<Texture2D>("MouseDiagRightResize")},
        {CardinalDirections.West, Resources.Load<Texture2D>("MouseHorzResize")},
        {CardinalDirections.Northwest, Resources.Load<Texture2D>("MouseDiagLeftResize")}
    };
    
// ~ Non-Static
    
// ~~ public
    public bool locked;
    
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
    public CardinalDirections ResizeDirection { 
        get; set;
    }

// ~~ private
    
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
    public static ResizeHandleRect GetRect(CardinalDirections resizeDirection, ViewData windowData) {
        GameObject result = new GameObject(resizeDirection + " Resize Handle");

        ResizeHandleRect resultMono = result.AddComponent<ResizeHandleRect>();
        resultMono.ResizeDirection = resizeDirection;
        resultMono.ViewData = windowData;
        
        return resultMono;
    }
    
// ~~ private
    
// ~ Non-Static
    
// ~~ public
    public void OnDrag(PointerEventData pData) {
//      If the pointer is off screen, do nothing.
        if (!pData.IsOnScreen() || locked) 
        {
            return;
        }

//      Get the signs for operations on size and position.
        Vector4 signs = GetSigns(pData);

//      Get the absolute delta between pointer position and handle position.
        Vector2 delta = pData.DeltaPosition(transform.position);

        float deltaSizeX = delta.x * signs.x;
        float deltaSizeY = delta.y * signs.y;

        float deltaPosX = delta.x * signs.z * .5f;
        float deltaPosY = delta.y * signs.w * .5f;
 
        ViewData.InnerWidth += deltaSizeX;
        ViewData.InnerHeight += deltaSizeY; 

        ViewData.PosX += deltaPosX;
        ViewData.PosY += deltaPosY;
   }

    public void OnPointerEnter(PointerEventData pData) {
        if (!locked) {
            Texture2D resizeIcon = Icons[ResizeDirection];
            Vector2 pointerPos = POINTER_OFFSET;       
            Cursor.SetCursor(resizeIcon, pointerPos, CursorMode.Auto);
        }
    }
    
    public void OnPointerExit(PointerEventData pData) {
        if (!locked) {
            Cursor.SetCursor(null, Vector3.zero, CursorMode.Auto);
        }
    }


   
// ~~ private
    protected override void HandleViewDataChanged(ViewData data) {
        BGColor = data.BorderBGColor;
        RectTransform.anchorMin = GetHandleAnchor(ResizeDirection, data); 
        RectTransform.anchorMax = RectTransform.anchorMin;
        RectTransform.sizeDelta = GetHandleSize(ResizeDirection, data);
    }

/// <summary>
/// Helper method for retrieving the correct signs for resizing and positioning
/// based on pointer position relative to this handle.
/// </summary>
/// <param name="pData">The PointerEventData containing the pointers position.</param>
/// <returns>A Vector4, with the following relations:
///          x -> east <-> west resize sign
///          y -> north <-> south resize sign
///          z -> east <-> west re-position sign
///          w -> north <-> south re-position sign.true
/// </returns>
    private Vector4 GetSigns(PointerEventData pData) {
        Vector4 result = Vector4.zero;

//      Set of booleans representing whether the view data has reached
//      its minimum/maximum dimension on a given axis.
        bool isMinWidth = ViewData.TotalWidth == ViewData.MinTotalWidth;
        bool isMaxWidth = ViewData.TotalWidth == ViewData.MaxTotalWidth;
        bool isMinHeight = ViewData.TotalHeight == ViewData.MinTotalHeight;
        bool isMaxHeight = ViewData.TotalHeight == ViewData.MaxTotalHeight;

        if (pData.IsEastOf(transform.position)) {
//          x -> east <-> west resize sign.
            result.x = EastWestResizeSigns[ResizeDirection][0];
//          z -> east <-> west re-position sign.
            result.z = EastWestPosSigns[ResizeDirection][0];
        }
        else {
//          Same as above.
            result.x = EastWestResizeSigns[ResizeDirection][1];
            result.z = EastWestPosSigns[ResizeDirection][1];
        }

        if (pData.IsNorthOf(transform.position)) {
//          y -> north <-> south resize sign.
            result.y = NorthSouthResizeSigns[ResizeDirection][0];
//          w -> north <-> south re-position sign.
            result.w = NorthSouthPosSigns[ResizeDirection][0];
        }
        else {
//          Same as above.
            result.y = NorthSouthResizeSigns[ResizeDirection][1];
            result.w = NorthSouthPosSigns[ResizeDirection][1];
        }

//      If a dimension has reached its min/max, set the sign
//      for that dimension to zero.
        if (isMinWidth && result.x < 0) {
            result.x = 0;
            result.z = 0;
        }

        if (isMaxWidth && result.x > 0) {
            result.x = 0;
            result.z = 0;
        }

        if (isMinHeight && result.y < 0) {
            result.y = 0;
            result.w = 0;
        }

        if (isMaxHeight && result.y > 0) {
            result.y = 0;
            result.w = 0;
        }

        return result;
    }

    private Vector2 GetHandleAnchor(CardinalDirections referencePoint, ViewData data) {
        try {
            switch (referencePoint) {
                case CardinalDirections.North:
                    return new Vector2(.5f, data.PercentNorthBorderCenterHeight);
                case CardinalDirections.Northeast:
                    return new Vector2(data.PercentEastBorderCenterWidth, data.PercentNorthBorderCenterHeight);
                case CardinalDirections.East:
                    return new Vector2(data.PercentEastBorderCenterWidth, .5f);
                case CardinalDirections.Southeast:
                    return new Vector2(data.PercentEastBorderCenterWidth, data.PercentSouthBorderCenterHeight);
                case CardinalDirections.South:
                    return new Vector2(.5f, data.PercentSouthBorderCenterHeight);
                case CardinalDirections.Southwest:
                    return new Vector2(data.PercentWestBorderCenterWidth, data.PercentSouthBorderCenterHeight);
                case CardinalDirections.West:
                    return new Vector2(data.PercentWestBorderCenterWidth, .5f);
                case CardinalDirections.Northwest:
                    return new Vector2(data.PercentWestBorderCenterWidth, data.PercentNorthBorderCenterHeight);
                default:
                    throw new System.NotImplementedException("ResizeHandleRect has not implemented "
                        + referencePoint + " for GetHandleAnchor(CardinalReferencePoints referencePoint.");
            }
        }
        catch (System.Exception e) {
            Debug.Log(e);
            Debug.Log("Returning Vector2.negativeInfinity as error value.");
            return Vector2.negativeInfinity;
        }
    }

    private Vector2 GetHandleSize(CardinalDirections referencePoint, ViewData data) {
        try {
            float widthLessCorners = data.TotalWidth - (data.BorderThickness * 2);
            float heightLessCorners = data.TotalHeight - (data.BorderThickness * 2);

            switch (referencePoint) {
                case CardinalDirections.North:
                    return new Vector2(widthLessCorners, data.BorderThickness);
                case CardinalDirections.Northeast:
                    return new Vector2(data.BorderThickness, data.BorderThickness);
                case CardinalDirections.East:
                    return new Vector2(data.BorderThickness, heightLessCorners);
                case CardinalDirections.Southeast:
                    return new Vector2(data.BorderThickness, data.BorderThickness);
                case CardinalDirections.South:
                    return new Vector2(widthLessCorners, data.BorderThickness);
                case CardinalDirections.Southwest:
                    return new Vector2(data.BorderThickness, data.BorderThickness);
                case CardinalDirections.West:
                    return new Vector2(data.BorderThickness, heightLessCorners);
                case CardinalDirections.Northwest:
                    return new Vector2(data.BorderThickness, data.BorderThickness);
                default:
                    throw new System.NotImplementedException("ResizeHandleRect has not implemented "
                        + referencePoint + " for GetHandleSize(CardinalReferencePoints referencePoint.");
            }
        }
        catch (System.Exception e) {
            Debug.Log(e);
            Debug.Log("Returning Vector2.negativeInfinity as error value.");
            return Vector2.negativeInfinity;
        }
    }
 
    private Vector2 GetPointerDelta(PointerEventData pData) {
        float deltaX = Mathf.Abs(gameObject.transform.position.x - pData.position.x);
        float deltaY = Mathf.Abs(gameObject.transform.position.y - pData.position.y);

        return new Vector2(
            deltaX,
            deltaY
        ); 
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