using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer), typeof(Collider))]
public abstract class Unit :
MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerDownHandler,
IPointerUpHandler,
IPointerClickHandler,
IInitializePotentialDragHandler,
IBeginDragHandler,
IDragHandler,
IEndDragHandler,
IDropHandler,
IScrollHandler,
IUpdateSelectedHandler,
ISelectHandler,
IDeselectHandler,
IMoveHandler,
ISubmitHandler,
ICancelHandler
{
// FIELDS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public
    public UnitData unitData;
    public Color unitColor;
    public Sprite portrait;

    public AttributeData AttributeData { 
        get {
            return _attributeData;
        }
    }

    public string InstanceID {
        get {
            return this.GetInstanceID().ToString();
        }
    }
    
// ~~ private
    protected AttributeData _attributeData;
    protected PortraitData _portraitData;
    protected DescriptionData _descriptionData;
    protected Renderer _renderer;
    protected Material _material;
    protected Color _cachedUnitColor;
    protected Color _hoverUnitColor;
    protected Color _clickUnitColor;
    protected bool _interactable;

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

// ~~ private

// ~ Non-Static

// ~~ public
    public virtual void OnPointerEnter(PointerEventData pData) {
        Debug.Log("Pointer enter " + name);
        _material.color = _hoverUnitColor;
    }
    
    public virtual void OnPointerExit(PointerEventData pData) {
        Debug.Log("Pointer exit: " + name);
        if (!EventSystem.current.currentSelectedGameObject == this.gameObject)
            _material.color = _cachedUnitColor;
    }
    
    public virtual void OnPointerDown(PointerEventData pData) {
        Debug.Log("Pointer down: " + name);
        _material.color = _clickUnitColor;
    }
    
    public virtual void OnPointerUp(PointerEventData pData) {
        Debug.Log("Pointer Up: " + name);
        _material.color = _hoverUnitColor;
    }
    
    public virtual void OnPointerClick(PointerEventData pData) {
        Debug.Log("Pointer Click: " + name);
        if (_interactable)
            UnitEvents.OnUnitSelected.Invoke(this);
    }
    
    public virtual void OnInitializePotentialDrag(PointerEventData pData) {
        Debug.Log("Potential Drag: " + name);
    }

    public virtual void OnBeginDrag(PointerEventData pData) {
        Debug.Log("Potential Drag: " + name);
    }
    
    public virtual void OnDrag(PointerEventData pData) {
        Debug.Log("Drag: " + name);
    }

    public virtual void OnEndDrag(PointerEventData pData) {
        Debug.Log("End Drag: " + name);
    }
    
    public virtual void OnDrop(PointerEventData pData) {
        Debug.Log("Drop: " + name);
    }
    
    public virtual void OnScroll(PointerEventData pData) {
        Debug.Log("Scroll: " + name);
    }
    
    public virtual void OnUpdateSelected(BaseEventData bData) {
        //Debug.Log("Update Selected: " + name);
    }   
    
    public virtual void OnSelect(BaseEventData bData) {
        Debug.Log("Select: " + name);
    }
    
    public virtual void OnDeselect(BaseEventData bData) {
        Debug.Log("Deselect: " + name);
    }
    
    public virtual void OnMove(AxisEventData aData) {
        Debug.Log("Move: " + name);
    }
    
    public virtual void OnSubmit(BaseEventData bData) {
        Debug.Log("Submit: " + name);
    }
    
    public virtual void OnCancel(BaseEventData bData) {
        Debug.Log("Cancel: " + name);
    }

    public virtual void OnUnitSelected(Unit unit) {
        if (unit == this && _interactable) {
            Debug.Log("Unit Selected: " + name);
            RootWindows.Subject(InstanceID).ShowDetail();
            if (!GameObject.Find("SelectionRing(Clone)")) {
                GameObject selectionRing = 
                    GameObject.Instantiate(
                        Resources.Load("SelectionRing"),
                        transform.Feet(),
                        Quaternion.identity,
                        this.transform
                    ) as GameObject;
                selectionRing.transform.SetParent(this.transform, false);
            }
            else {
                GameObject.Find("SelectionRing(Clone)")
                    .transform.SetParent(this.transform, false);
            }
        }
        else {
            Debug.Log("Unit Not Selected: " + name);
            RootWindows.Subject(InstanceID).HideDetail();
        }
    }

    public virtual void OnUnitStartAbility(Unit unit) {
        if (unit == this)
            _interactable = true;
        else
            _interactable = false;
    }

    public virtual void OnUnitEndAbility(Unit unit) {
        _interactable = true;
    }

    public void ChangeAttributeOverTime(string attribute, float change, float time) {
        StartCoroutine(ChangeAttributeOverTimeCoroutine(attribute, change, time));
    }

    public void ApplyDamage(float damage) {
        ChangeAttributeOverTime(AttributeNames.HP, -damage, damage);
    }

    public void ApplyHealing(float healing) {
        ChangeAttributeOverTime(AttributeNames.HP, healing, healing);
    }

    public IEnumerator ChangeAttributeOverTimeCoroutine(
        string attribute, 
        float change, 
        float time
    ) {
        if (time < 0) {
            throw new System.NotImplementedException("Negative values for float param [time] " +
                " have not been implemented.");
        }
        float elapsed = 0;
        float initialValue = _attributeData.GetAttribute(attribute);

        while (elapsed <= time) {
            float changeThisFrame = 
                elapsed == 0 ? 0 : change * (Time.deltaTime / time);
            elapsed += Time.deltaTime;
            _attributeData.ChangeAttribute(attribute, changeThisFrame);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _attributeData.SetAttribute(
            attribute,
            initialValue + change
        );

        UnitEvents.OnUnitEndAbility.Invoke(this);
    }

// ~~ private
    protected void Awake() {
        _attributeData = new AttributeData();
        _attributeData.SetAttribute(AttributeNames.HP, unitData.HP);
        _attributeData.SetAttribute(AttributeNames.AP, unitData.AP);
        _portraitData = new PortraitData(portrait);
        _descriptionData = new DescriptionData(unitData.description);
        transform.position = 
            transform.position + (transform.up * (transform.localScale.y));
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _material.color = unitColor;
        _cachedUnitColor = unitColor;
        _hoverUnitColor = _cachedUnitColor.GetHighlightedColor(.75f);
        _clickUnitColor = _cachedUnitColor.GetHighlightedColor(.95f);
        _interactable = true;
    }
    
    private void OnEnable() {
    
    }
    
    private void Reset() {
    
    }
    
    protected void Start() {
        AddUnitListeners();
        RegisterViewModels();
    }
    
    private void FixedUpdate() {
    
    }
    
    private void Update() {
    
    }
    
    private void LateUpdate() {
    
    }
    
    private void OnDrawGizmos() {
    
    }
    
    private void OnDisable() {
    
    }
    
    protected void OnDestroy() {
        DeregisterViewModels();
        RemoveUnitListeners();
    }

    protected void RegisterViewModels() {
        RootWindows.Register(InstanceID, AttributeData);
        RootWindows.Register(InstanceID, _portraitData);
        RootWindows.Register(InstanceID, _descriptionData);
    }

    protected void DeregisterViewModels() {
        RootWindows.Deregister(InstanceID, AttributeData);
        RootWindows.Deregister(InstanceID, _portraitData);
        RootWindows.Deregister(InstanceID, _descriptionData);
    }

    protected void AddUnitListeners() {
        UnitEvents.OnUnitSelected.AddListener(OnUnitSelected);
        UnitEvents.OnUnitStartAbility.AddListener(OnUnitStartAbility);
        UnitEvents.OnUnitEndAbility.AddListener(OnUnitEndAbility);
    }

    protected void RemoveUnitListeners() {
        UnitEvents.OnUnitSelected.RemoveListener(OnUnitSelected);
        UnitEvents.OnUnitStartAbility.RemoveListener(OnUnitStartAbility);
        UnitEvents.OnUnitEndAbility.RemoveListener(OnUnitEndAbility);
    }

    protected bool EnoughAP(float apCost) {
        return (AttributeData.GetAttribute(AttributeNames.AP) >= apCost);
    }

    protected bool IsOtherUnit(GameObject obj) {
        return (obj.GetComponent<Unit>() && !(obj == this.gameObject));
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
