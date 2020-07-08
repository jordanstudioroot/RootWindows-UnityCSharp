using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer), typeof(RectTransform), typeof(Image))]
public abstract class ViewRect : MonoBehaviour {
    private Image _background;
    protected ViewData _viewData;

    public ViewData ViewData {
        protected get {
            return _viewData;
        }

        set {
            if (_viewData == null) {
                _viewData = value;
                _viewData.OnViewDataChanged += HandleViewDataChanged;
                HandleViewDataChanged(_viewData);
            }
        }
    }

    public Color BGColor {
        get { return _background.color; }
        set { _background.color = value; }
    }

    public RectTransform RectTransform {
        get {
            return GetComponent<RectTransform>();
        }
    }

    public Vector2 SizeDelta {
        get {
            return RectTransform.sizeDelta;
        }
        set {
            RectTransform.sizeDelta = value;
        }
    }

    public Vector2 ParentSizeDelta {
        get {
            if (transform.parent && transform.parent.GetComponent<RectTransform>()) {
                return transform.parent.GetComponent<RectTransform>().sizeDelta;
            }
            return SizeDelta;
        }
    }

    public ViewRect[] ViewRectChildren {
        get {
            return this.GetComponentsInDirectChildren<ViewRect>();
        }
    }

    public Transform[] AllChildren {
        get {
            return this.GetComponentsInDirectChildren<Transform>();
        }
    }

    public ViewRect[] ViewRectSiblings {
        get {
            if (this.transform.parent) {
                return this.transform.parent.GetComponentsInDirectChildren<ViewRect>();
            }
            
            return new ViewRect[0];
        }
    }

    public Transform[] AllSiblings {
        get {
            if (this.transform.parent) {
                return this.transform.parent.GetComponentsInDirectChildren<Transform>();
            }
            return new Transform[0];
        }
    }

    public ViewRect Parent {
        get {
            if (transform.parent && transform.parent.GetComponent<ViewRect>())
                return transform.parent.GetComponent<ViewRect>();
            return this;
        }
    }

    protected virtual void OnDestroy() {
        ViewData.OnViewDataChanged -= HandleViewDataChanged;
    }

    protected void Awake() {
        _background = GetComponent<Image>();
    }

    public void ParentToViewRect(ViewRect parent) {
        this.transform.SetParent(parent.transform, false);
        FitToParent();
    }

    public void FitToParent() {
        if (this.transform.parent && this.transform.parent.GetComponent<RectTransform>()) {
            RectTransform.sizeDelta = 
                this.transform.parent.GetComponent<RectTransform>().sizeDelta;
        }
    }
    
    protected abstract void HandleViewDataChanged(ViewData data);
}