using UnityEngine;
using UnityEngine.EventSystems;

public class Warrior : Unit
{
    private new void Awake() {
        base.Awake();
    }
    
    private void OnEnable() {
    
    }
    
    private void Reset() {
    
    }
    
    private new void Start() {
        base.Start();
        RootWindows.Register(InstanceID, OnSlashStart, Slash);
        RootWindows.Register(InstanceID, Heal);
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
    
    private new void OnDestroy() {
        base.OnDestroy();
        RootWindows.Deregister(InstanceID, OnSlashStart, Slash);
        RootWindows.Deregister(InstanceID, Heal);
    }

    public override void OnPointerEnter(PointerEventData pData)
    {
        base.OnPointerEnter(pData);
    }

    public override void OnPointerExit(PointerEventData pData)
    {
        base.OnPointerExit(pData);
    }

    public override void OnPointerDown(PointerEventData pData)
    {
        base.OnPointerDown(pData);
    }

    public override void OnPointerUp(PointerEventData pData)
    {
        base.OnPointerUp(pData);
    }

    public override void OnPointerClick(PointerEventData pData)
    {
        base.OnPointerClick(pData);
    }

    public override void OnInitializePotentialDrag(PointerEventData pData)
    {
        base.OnInitializePotentialDrag(pData);
    }

    public override void OnBeginDrag(PointerEventData pData)
    {
        base.OnBeginDrag(pData);
    }

    public override void OnDrag(PointerEventData pData)
    {
        base.OnDrag(pData);
    }

    public override void OnEndDrag(PointerEventData pData)
    {
        base.OnEndDrag(pData);
    }

    public override void OnDrop(PointerEventData pData)
    {
        base.OnDrop(pData);
    }

    public override void OnScroll(PointerEventData pData)
    {
        base.OnScroll(pData);
    }

    public override void OnUpdateSelected(BaseEventData bData)
    {
        base.OnUpdateSelected(bData);
    }

    public override void OnSelect(BaseEventData bData)
    {
        base.OnSelect(bData);
    }

    public override void OnDeselect(BaseEventData bData)
    {
        base.OnDeselect(bData);
    }

    public override void OnMove(AxisEventData aData)
    {
        base.OnMove(aData);
    }

    public override void OnSubmit(BaseEventData bData)
    {
        base.OnSubmit(bData);
    }

    public override void OnCancel(BaseEventData bData)
    {
        base.OnCancel(bData);
    }

    public override void OnUnitSelected(Unit unit) {
        base.OnUnitSelected(unit);
        
        if (unit == this && _interactable) {
            RootWindows.Subject(InstanceID).ShowActionBar();
        }
        else {
            RootWindows.Subject(InstanceID).HideActionBar();
        }
    }

    private void OnSlashStart() {
        UnitEvents.OnUnitStartAbility.Invoke(this);
    }

    private void Slash(GameObject[] onPointer) {
        Debug.Log("Slashing");
        if (EnoughAP(1f)) {
            foreach(GameObject obj in onPointer) {
                if (IsOtherUnit(obj)) {
                    obj.GetComponent<Unit>().ApplyDamage(1f);
                    break;
                }
            }
        }
        else {
            Debug.Log("Not enough AP to slash!");
        }
    }

    private void Heal() {
        UnitEvents.OnUnitStartAbility.Invoke(this);
        Debug.Log("Healing.");
        if(EnoughAP(1f)) {
            ApplyHealing(1f);
        }
        else {
            Debug.Log("Not enough AP to heal!");
        }
        UnitEvents.OnUnitEndAbility.Invoke(this);
    }
}
