using UnityEngine;

public class ViewData {
// FIELDS

// ~ Static

// ~~ public
    /// <summary>
    /// The default border color for a view.
    /// </summary>
    public static readonly Color DefaultBorderBGColor = new Color(0f, 0f, 0f, .25f); // Semi-transparent black

    /// <summary>
    /// The default content background color for a view.
    /// </summary>
    public static readonly Color DefaultContentBGColor = new Color(1f, 1f, 1f, .25f); // Semi-transparent white

    /// <summary>
    /// The default background color for an object targeted action.
    /// </summary>
    public static readonly Color DefaultObjectActionBGColor = new Color(0f, 0f, 255f); // blue

    /// <summary>
    /// The default background color for a position targeted action.
    /// </summary>
    public static readonly Color DefaultLocationActionBGColor = new Color(0f, 255f, 0f); // green

    /// <summary>
    /// The default background color for a self targeted action.
    /// </summary>
    public static readonly Color DefaultSelfActionBGColor = new Color(255f, 0f, 0f); // red

    /// <summary>
    /// The default background color for the move handle.
    /// </summary>
    /// <returns></returns>
    public static readonly Color DefaultMoveHandleBGColor = new Color(0f, 0f, 0f, 1f); // Solid black
    public static readonly float DefaultBorderThickness = AppWindowMetrics.FullAppWindow.x * .005f;
    public static readonly float DefaultMoveHandleHeight = AppWindowMetrics.FullAppWindow.y / 40f;
    public static readonly float DefaultMinTotalWidth = AppWindowMetrics.FullAppWindow.x * .2f;
    public static readonly float DefaultMinTotalHeight = AppWindowMetrics.FullAppWindow.y * .4f;
    public static readonly float DefaultInnerWidth = DefaultMinTotalWidth - DefaultBorderThickness;
    public static readonly float DefaultInnerHeight = DefaultMinTotalHeight - DefaultBorderThickness;
    public static readonly float DefaultMaxTotalWidth = AppWindowMetrics.FullAppWindow.x;
    public static readonly float DefaultMaxTotalHeight = AppWindowMetrics.FullAppWindow.y;
    public static readonly float DefaultViewPosX = AppWindowMetrics.FullAppWindow.x * .5f;
    public static readonly float DefaultViewPosY = AppWindowMetrics.FullAppWindow.y * .5f;

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    private Color _borderBGColor;
    private Color _contentBGColor;
    private Color _subjectBGColor;
    private Color _selfActionBGColor;
    private Color _locationActionBGColor;
    private Color _objectActionBGColor;
    private float _borderThickness;
    private float _innerHeight;
    private float _innerWidth;
    private float _maxTotalHeight;
    private float _maxTotalWidth;
    private float _minTotalHeight;
    private float _minTotalWidth;
    private float _posX;
    private float _posY;
    private float _moveHandleHeight;
    private string _windowName;
    private int _numFlexRects;

// CONSTRUCTORS
    /// <summary>
    /// A class encapsulating data about the geometric facts about a given view.
    /// </summary>
    /// <param name="contentAreaWidth">
    ///     The width of the content area.
    /// </param>
    /// <param name="contentAreaHeight">
    ///     The height of the content area.
    /// </param>
    /// <param name="screenPositionX">
    ///     The screen position of the center of the view along the screen X axis
    /// </param>
    /// <param name="screenPositionY">
    ///     The screen position of the center of the view along the screen Y axis.
    /// </param>
    /// <param name="borderThickness">
    ///     The thickness of the border in the basic screen measurement unit being used.
    /// </param>
    /// <param name="contentAreaBGColor">
    ///     The background color of the content area.
    /// </param>
    /// <param name="moveHandleBGColor">
    ///     The background color of the move handle.
    /// </param>
    /// <param name="borderBGColor">
    ///     The background color of the border.
    /// </param>
    public ViewData(
        float contentAreaWidth,
        float contentAreaHeight,
        float moveHandleHeight,
        float borderThickness,
        float screenPositionX,
        float screenPositionY,
        Color contentAreaBGColor,
        Color moveHandleBGColor,
        Color borderBGColor,
        Color selfActionBGColor,
        Color positionActionBGColor,
        Color objectActionBGColor
    )
    {
        BorderBGColor = borderBGColor;
        BorderThickness = borderThickness;
        ContentBGColor = contentAreaBGColor;
        SelfActionBGColor = selfActionBGColor;
        LocationActionBGColor = positionActionBGColor;
        ObjectActionBGColor = objectActionBGColor;
        InnerHeight = contentAreaHeight;
        InnerWidth = contentAreaWidth;
        MoveHandleBGColor = moveHandleBGColor;
        PosX = screenPositionX;
        PosY = screenPositionY;
    }

    public ViewData() {
        MinTotalWidth = DefaultMinTotalWidth;
        MaxTotalWidth = DefaultMaxTotalWidth;
        MinTotalHeight = DefaultMinTotalHeight;
        MaxTotalHeight = DefaultMaxTotalHeight;

        BorderBGColor = DefaultBorderBGColor;
        ContentBGColor = DefaultContentBGColor;
        MoveHandleBGColor = DefaultMoveHandleBGColor;
        SelfActionBGColor = DefaultSelfActionBGColor;
        LocationActionBGColor = DefaultLocationActionBGColor;
        ObjectActionBGColor = DefaultObjectActionBGColor;

        BorderThickness = DefaultBorderThickness;
        MoveHandleHeight = DefaultMoveHandleHeight;

        InnerWidth = DefaultInnerWidth;
        InnerHeight = DefaultInnerHeight;

        PosX = DefaultViewPosX;
        PosY = DefaultViewPosY;
    }
    
// EVENTS

// ~Static

// ~~public

// ~~private

// ~Non-Static

// ~~public
    /// <summary>
    /// An event which any class wishing to respond to a change in data for a given instance of ViewData should subscribe to
    /// for that particular ViewData instance.
    /// </summary>
    public event OnViewDataChangedDelegate OnViewDataChanged;

// ~~private

// PROPERTIES

// ~Static

// ~~public

// ~~private

// ~Non-Static

// ~~public
    public string ViewName {
        get { return _windowName; }
        set {
            _windowName = value;

            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public float MoveHandleHeight {
        get {
            return _moveHandleHeight;
        }
        set {
            _moveHandleHeight = value;
        }
    }
   
    public float InnerWidth {
        get { return _innerWidth; }
        set {
            float totalValue = value + (2f * _borderThickness);

            totalValue = Mathf.Clamp(totalValue, _minTotalWidth, _maxTotalWidth);

            _innerWidth = totalValue - (2f * _borderThickness);
        
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public float InnerHeight {
        get { return _innerHeight; } 
        set {
            float totalValue = value + (2f * _borderThickness);

            totalValue = Mathf.Clamp(totalValue, _minTotalHeight, _maxTotalHeight);
            
            _innerHeight = totalValue - (2f * _borderThickness);

            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Vector2 InnerSize {
        set {
            InnerWidth = value.x;
            InnerHeight = value.y;
        }
    }

    public float PosX {
        get { return _posX; } 
        set {
            _posX = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public float PosY {
        get { return _posY; }
        set {
            _posY = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Vector2 Pos {
        set {
            PosX = value.x;
            PosY = value.y;
        }
    }

    public float BorderThickness {
        get { return _borderThickness; } 
        set {
            _borderThickness = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Color ContentBGColor {
        get { return _contentBGColor; }
        set {
            _contentBGColor = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Color MoveHandleBGColor {
        get { return _subjectBGColor; } 
        set {
            _subjectBGColor = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Color BorderBGColor {
        get { return _borderBGColor; }
        set {
            _borderBGColor = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Color SelfActionBGColor {
        get {
            return _selfActionBGColor;
        }

        set {
            _selfActionBGColor = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Color LocationActionBGColor {
        get {
            return _locationActionBGColor;
        }

        set {
            _locationActionBGColor = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public Color ObjectActionBGColor {
        get {
            return _objectActionBGColor;
        }

        set {
            _objectActionBGColor = value;
            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public float TotalWidth {
        get { return  InnerWidth + (2f * BorderThickness); }
    }
   
    public float TotalHeight {
        get { return InnerHeight + (2f * BorderThickness); }
    }

    public float SubjectWidth {
        get { return InnerWidth; }
    }

    public float ContentWidth {
        get { return InnerWidth; }
    }

        public float ContentHeight {
        get { return InnerHeight - MoveHandleHeight; }
    }

    public float MinTotalWidth {
        get { return _minTotalWidth; }
        set {
            if (value > 0) {
                _minTotalWidth = value;

                if (_minTotalWidth > _maxTotalWidth) {
                    _maxTotalHeight = _minTotalWidth;
                }

                if (OnViewDataChanged != null) {
                    OnViewDataChanged(this);
                }
            }
        }
    }

    public float MinTotalHeight {
        get { return _minTotalHeight; } 
        set {
            if (value > 0) {
                _minTotalHeight = value;

                if (_minTotalHeight > _maxTotalHeight) {
                    _maxTotalHeight = _minTotalHeight;
                }

                if (OnViewDataChanged != null) {
                    OnViewDataChanged(this);
                }
            }
        }
    }

    public float MaxTotalWidth {
        get { return _maxTotalWidth;} 
        set {
            if (value < _minTotalWidth) {
                _minTotalWidth = value;
                _maxTotalWidth = value;
            }
            else {
                _maxTotalWidth = value;
            }

            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public float MaxTotalHeight {
        get { return _maxTotalHeight; }
        set {
            if (value < _minTotalHeight) {
                _minTotalHeight = value;
                _maxTotalHeight = value;
            }
            else {
                _maxTotalHeight = value;
            }

            if (OnViewDataChanged != null) {
                OnViewDataChanged(this);
            }
        }
    }

    public float PercentBorderThickness {
        get { return BorderThickness/TotalWidth; }
    }

    public float PercentBorderHeight {
        get { return BorderThickness/TotalHeight; }
    }

    public float PercentSubjectWidth {
        get { return InnerWidth/TotalWidth; }
    }

    public float PercentSubjectHeight {
        get { return DefaultMoveHandleHeight/TotalHeight; }
    }
    public float PercentContentWidth {
        get { return InnerWidth/TotalWidth; }
    }

    public float PercentContentHeight {
        get { return ContentHeight/TotalHeight; }
    }

    public float PercentSubjectCenterY  {
        get { return 1f - PercentBorderHeight - (PercentSubjectHeight / 2f); }
    }

    public float PercentContentCenterY {
        get { 
            return 1f - PercentBorderHeight - PercentSubjectHeight - (PercentContentHeight / 2f); 
        }
    }

    public float PercentWestBorderCenterWidth {
        get { return PercentBorderThickness * .5f; }
    }

    public float PercentEastBorderCenterWidth {
        get { return 1f - (PercentBorderThickness * .5f); }
    }

    public float PercentNorthBorderCenterHeight {
        get { return 1f - (PercentBorderHeight * .5f); }
    }

    public float PercentSouthBorderCenterHeight {
        get { return (PercentBorderHeight * .5f); }
    }

// ~~private

}

public delegate void OnViewDataChangedDelegate(ViewData data);
