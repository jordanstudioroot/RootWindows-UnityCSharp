using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(RectTransform))]
public abstract class View : MonoBehaviour
{
    // FIELDS ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    private Dictionary<CardinalDirections, ResizeHandleRect> _resizeHandles;
    private MoveHandleRect _moveHandle;
    private ViewData _viewData;
    private RectTransform _rectTransform;
    private ContentRect _contentRect;
    protected CardinalDirections _closestCardinalPosition;
    
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
    public ViewData ViewData {
        get {
            if (_viewData == null) {
                throw new System.NullReferenceException("WindowRect on " + gameObject.name +
                    " has not been assigned WindowData");
            }
            return _viewData;
        }

        set {
            if (_viewData == null) {
                _viewData = value;
                _viewData.OnViewDataChanged += (_data) => HandleViewDataChanged(_data);
                HandleViewDataChanged(_viewData);
            }
        }
    }
    
    // ~~ private
    protected RectTransform RectTransform {
        get {
            return _rectTransform;
        }
    }

    public ContentRect ContentRect {
        get {
            if (_contentRect == null) {
                throw new System.NullReferenceException("ContentRect on " + gameObject.name +
                    " has not been assigned.");
            }
            return _contentRect;
        }

        set {
            if (_contentRect == null) {
                _contentRect = value;
            }
            else {
                throw new System.ArgumentException("ContentRect on " + gameObject.name +
                    " has already been assigned.");
            }
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
    public abstract void SetSize(ViewSizes size);
  
    public void SetLocation(CardinalDirections location) {
        switch (location) {
            case CardinalDirections.North:
                ViewData.PosX = Screen.width / 2f;
                ViewData.PosY = Screen.height - (ViewData.TotalHeight / 2f);
                _closestCardinalPosition = CardinalDirections.North;
                break;
            case CardinalDirections.Northeast:
                ViewData.PosX = Screen.width - (ViewData.TotalWidth / 2f);
                ViewData.PosY = Screen.height - (ViewData.TotalHeight / 2f);
                _closestCardinalPosition = CardinalDirections.Northeast;
                break;
            case CardinalDirections.East:
                ViewData.PosX = Screen.width - (ViewData.TotalWidth / 2f);
                ViewData.PosY = Screen.height / 2f;
                _closestCardinalPosition = CardinalDirections.East;
                break;
            case CardinalDirections.Southeast:
                ViewData.PosX = Screen.width - (ViewData.TotalWidth / 2f);
                ViewData.PosY = ViewData.TotalHeight / 2f;
                _closestCardinalPosition = CardinalDirections.Southeast;
                break;
            case CardinalDirections.South:
                ViewData.PosX = Screen.width / 2f;
                ViewData.PosY = ViewData.TotalHeight / 2f;
                _closestCardinalPosition = CardinalDirections.South;
                break;
            case CardinalDirections.Southwest:
                ViewData.PosX = ViewData.TotalWidth / 2f;
                ViewData.PosY = ViewData.TotalHeight / 2f;            
                _closestCardinalPosition = CardinalDirections.Southwest;
                break;
            case CardinalDirections.West:
                ViewData.PosX = ViewData.TotalWidth / 2f;
                ViewData.PosY = Screen.height / 2f;
                _closestCardinalPosition = CardinalDirections.West;
                break;
            case CardinalDirections.Northwest:
                ViewData.PosX = ViewData.TotalWidth / 2f;
                ViewData.PosY = Screen.height - (ViewData.TotalHeight / 2f);
                _closestCardinalPosition = CardinalDirections.Northwest;
                break;
            case CardinalDirections.Center:
                ViewData.PosX = Screen.width / 2f;
                ViewData.PosY = Screen.height / 2f;
                _closestCardinalPosition = CardinalDirections.Center;
                break;
        }
    }

    public void SetLocation(Vector2 location) {
        ViewData.PosX = Mathf.Clamp(location.x, (ViewData.TotalWidth * .5f), Screen.width);
        ViewData.PosY = Mathf.Clamp(location.y, (ViewData.TotalHeight * .5f), Screen.height);

        _closestCardinalPosition = AppWindowMetrics.ClosestCardinalPoint(
            new Vector2(ViewData.PosX, ViewData.PosY)
        );
    }

    /// <summary>
    /// Snap the view to the closest cardinal position (north, south, east, etc...)
    /// </summary>
    public void Snap() {
        SetLocation(_closestCardinalPosition);
    }

    protected void Initialize(Canvas canvas) {
        transform.SetParent(canvas.transform, false);
        RectTransform.anchorMin = new Vector2(0f, 0f);
        RectTransform.anchorMax = RectTransform.anchorMin;
        ViewData = new ViewData();

        _moveHandle = MoveHandleRect.GetRect(ViewData);
        _contentRect = ContentRect.GetRect(ViewData);
        _contentRect.transform.SetParent(transform, false);

        ResizeHandleRect northResizeObj = ResizeHandleRect.GetRect(CardinalDirections.North, ViewData);
        ResizeHandleRect northeastResizeObj = ResizeHandleRect.GetRect(CardinalDirections.Northeast, ViewData);
        ResizeHandleRect eastResizeObj = ResizeHandleRect.GetRect(CardinalDirections.East, ViewData);
        ResizeHandleRect southeastResizeObj = ResizeHandleRect.GetRect(CardinalDirections.Southeast, ViewData);
        ResizeHandleRect southResizeObj = ResizeHandleRect.GetRect(CardinalDirections.South, ViewData);
        ResizeHandleRect southwestResizeObj = ResizeHandleRect.GetRect(CardinalDirections.Southwest, ViewData);
        ResizeHandleRect westResizeObj = ResizeHandleRect.GetRect(CardinalDirections.West, ViewData);
        ResizeHandleRect northwestResizeObj = ResizeHandleRect.GetRect(CardinalDirections.Northwest, ViewData);

        _resizeHandles.Add(CardinalDirections.North, northResizeObj);
        _resizeHandles.Add(CardinalDirections.Northeast, northeastResizeObj);
        _resizeHandles.Add(CardinalDirections.East, eastResizeObj);
        _resizeHandles.Add(CardinalDirections.Southeast, southeastResizeObj);
        _resizeHandles.Add(CardinalDirections.South, southResizeObj);
        _resizeHandles.Add(CardinalDirections.Southwest, southwestResizeObj);
        _resizeHandles.Add(CardinalDirections.West, westResizeObj);
        _resizeHandles.Add(CardinalDirections.Northwest, northwestResizeObj);
        
        foreach (KeyValuePair<CardinalDirections, ResizeHandleRect> pair in _resizeHandles) {
            pair.Value.transform.SetParent(transform, false);
        }
        
        _moveHandle.transform.SetParent(transform, false);
    }
   
    // ~~ private
    private void Awake() {
        _rectTransform = this.GetComponent<RectTransform>();
        _resizeHandles = new Dictionary<CardinalDirections, ResizeHandleRect>();
    }
    protected virtual void HandleViewDataChanged(ViewData viewData)
    {   
        Vector2 viewPos = new Vector2(ViewData.PosX, ViewData.PosY);
        Vector2 viewSize = new Vector2(ViewData.TotalWidth, ViewData.TotalHeight);

        RectTransform.anchoredPosition = viewPos;
        RectTransform.sizeDelta = viewSize;
    }

    public void SetLockedAllHandles(bool locked) {
        foreach (KeyValuePair<CardinalDirections, ResizeHandleRect> pair in _resizeHandles) {
            pair.Value.locked = locked;
        }
    }

    public void SetLockedHandle(bool locked, CardinalDirections handlePosition) {
        _resizeHandles[handlePosition].locked = locked;
    }

    public void SetLockedMoveHandle(bool locked) {
        _moveHandle.locked = locked;
    }

    public void Focus() {
        this.transform.SetAsLastSibling();
    }

    public void Clear() {
        ContentRect.Clear();
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