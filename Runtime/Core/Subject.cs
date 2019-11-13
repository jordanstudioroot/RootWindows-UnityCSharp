using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Subject : ISubject {
    // FIELDS ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public
    public IAttributeData _attributeData;
    public IDescriptionData _descriptionData;
    public IPortraitData _portraitData;

    // ~~ private
    private Canvas _canvas;
    private SubjectDetailView _detailView;
    private SubjectTooltipView _tooltipView;
    private ActionBarView _actionBarView;
    private List<Action> _selfAbilities;
    private Dictionary<Action, Action<Vector3>> _locationAbilities;
    private Dictionary<Action, Action<GameObject[]>> _objectAbilities;

    // CONSTRUCTORS ~~~~~~~~~~
    public Subject(Canvas canvas) {
        _canvas = canvas;
        _detailView = SubjectDetailView.GetView(canvas);
        _detailView.gameObject.SetActive(false);
        _actionBarView = ActionBarView.GetView(canvas);
        _actionBarView.gameObject.SetActive(false);
        _selfAbilities = new List<Action>();
        _locationAbilities = new Dictionary<Action, Action<Vector3>>();
        _objectAbilities = new Dictionary<Action, Action<GameObject[]>>();
    }

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
    public bool HasData {
        get {
            return (
                _attributeData != null ||
                _descriptionData != null ||
                _portraitData != null
            );
        }
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

    // ~~ private

    // ~ Non-Static

    // ~~ public
    public void RegisterOnDataChangedHandler(IViewData data) {
        data.OnDataChanged += HandleDataChanged;
    }

    public void DeregisterOnDataChangedHandler(IViewData data) {
        data.OnDataChanged -= HandleDataChanged;
    }

    public void Refresh() {
        if (_detailView)
            _detailView.Refresh(
                _attributeData, 
                _portraitData, 
                _descriptionData
            );
        if (_tooltipView)
            _tooltipView.Refresh(_attributeData);
        if (_actionBarView)
            _actionBarView.Refresh(
                _selfAbilities, 
                _locationAbilities, 
                _objectAbilities
            );
    }

    public void ShowDetail(
        bool sizeLocked = true,
        bool positionLocked = true
    ) {
        _detailView.gameObject.SetActive(true);
        _detailView.Refresh(_attributeData, _portraitData, _descriptionData);
        _detailView.transform.SetAsLastSibling();
        _detailView.SetLockedAllHandles(sizeLocked);
        _detailView.SetLockedMoveHandle(positionLocked);
    }
    
    public void ShowDetail(
        CardinalDirections location,
        ViewSizes size,
        bool sizeLocked = true, 
        bool positionLocked = true
    ) {
        _detailView.gameObject.SetActive(true);
        _detailView.SetSize(size);
        _detailView.SetLocation(location);
        _detailView.Refresh(_attributeData, _portraitData, _descriptionData);
        _detailView.transform.SetAsLastSibling();
        _detailView.SetLockedAllHandles(sizeLocked);
        _detailView.SetLockedMoveHandle(positionLocked);
    }

    public void ShowDetail(
        Vector2 location, 
        ViewSizes size = ViewSizes.Medium, 
        bool sizeLocked = true, 
        bool positionLocked = true
    ) {
        _detailView.gameObject.SetActive(true);
        _detailView.SetSize(size);
        _detailView.SetLocation(location);
        _detailView.Refresh(_attributeData, _portraitData, _descriptionData);
        _detailView.transform.SetAsLastSibling();
        _detailView.SetLockedAllHandles(sizeLocked);
        _detailView.SetLockedMoveHandle(positionLocked);
    }

    public void HideDetail() {
        _detailView.gameObject.SetActive(false);
    }

    public void ShowActionBar(
        bool sizeLocked = true,
        bool positionLocked = true
    ) {
        _actionBarView.gameObject.SetActive(true);
        _actionBarView.Refresh(_selfAbilities, _locationAbilities, _objectAbilities);
        _actionBarView.transform.SetAsLastSibling();
        _actionBarView.SetLockedAllHandles(sizeLocked);
        _actionBarView.SetLockedMoveHandle(positionLocked);
    }

    public void ShowActionBar(
        CardinalDirections location,
        ViewSizes size,
        bool sizeLocked = true,
        bool positionLocked = true
    ) {
        _actionBarView.gameObject.SetActive(true);
        _actionBarView.SetLocation(location);
        _actionBarView.SetSize(size);
        _actionBarView.Refresh(_selfAbilities, _locationAbilities, _objectAbilities);
        _actionBarView.transform.SetAsLastSibling();
        _actionBarView.SetLockedAllHandles(sizeLocked);
        _actionBarView.SetLockedMoveHandle(positionLocked);
    }

    public void HideActionBar() {
        _actionBarView.gameObject.SetActive(false);
    }

    public void ShowTooltip(ViewSizes size = ViewSizes.Medium)
    {
        throw new System.NotImplementedException();
    }

    public void HideTooltip() {
        throw new System.NotImplementedException();
    }

    public void TryAddData(IViewData data) {
        if (data is IAttributeData)
            _attributeData = data as IAttributeData;
        else if (data is IDescriptionData)
            _descriptionData = data as IDescriptionData;
        else if (data is IPortraitData)
            _portraitData = data as IPortraitData;

        Refresh();
        RegisterOnDataChangedHandler(data);
    }

    public void TryRemoveData(IViewData data) {
        if (data is IAttributeData)
            _attributeData = null;
        else if (data is IDescriptionData)
            _descriptionData = null;
        else if (data is IPortraitData)
            _portraitData = null;

        DeregisterOnDataChangedHandler(data);
    }

    public void TryAddAbility(
        Action onAbilityClick,
        Action onAbilityConfirm
    ) {
        // TODO Implement functionality for onAbilty click.
        if (_selfAbilities == null) {
            _selfAbilities = new List<Action>();
            _selfAbilities.Add(onAbilityConfirm);
            Refresh();
        }
        else if (!_selfAbilities.Contains(onAbilityConfirm)) {
            Refresh();
            _selfAbilities.Add(onAbilityConfirm);
        }
        else
            throw new ArgumentException(onAbilityConfirm.Method.Name + " already present on subject.");
    }

    public void TryAddAbility(
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    ) {
        if (_locationAbilities == null) {
            _locationAbilities = new Dictionary<Action, Action<Vector3>>();
            _locationAbilities.Add(onAbilityClick, onAbilityConfirm);
            Refresh();
        }
        else if (!_locationAbilities.ContainsKey(onAbilityClick)) {
            _locationAbilities.Add(onAbilityClick, onAbilityConfirm);
            Refresh();
        }
        else
            throw new ArgumentException(
                onAbilityConfirm.Method.Name + " already present on subject."
            );
    }

    public void AddAbility(
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    ) {
        if (_objectAbilities == null) {
            _objectAbilities = new Dictionary<Action, Action<GameObject[]>>();
            _objectAbilities.Add(onAbilityClick, onAbilityConfirm);
            Refresh();
        }
        else if (!_objectAbilities.ContainsKey(onAbilityClick)) {
            _objectAbilities.Add(onAbilityClick, onAbilityConfirm);
            Refresh();
        }
        else
            throw new ArgumentException(
                onAbilityConfirm.Method.Name + " already present on subject."
            );
    }

    public void RemoveAbility(Action onAbilityConfirm) {
        if(!_selfAbilities.Remove(onAbilityConfirm)) {
            throw new ArgumentException(onAbilityConfirm.Method.Name + " not present on subject.");
        }
        Refresh();
    }

    public void RemoveAbility(
        Action onAbilityClick = null, 
        Action<Vector3> onAbilityConfirm = null
    ) {
        if (onAbilityClick != null) {
            if(!_locationAbilities.Remove(onAbilityClick)) {
                throw new ArgumentException(
                    onAbilityConfirm.Method.Name + " not present on subject."
                );
            }
        }
        else if (onAbilityConfirm != null) {
            foreach (
                KeyValuePair<Action, Action<Vector3>> pair in _locationAbilities
            ) {
                if (pair.Value == onAbilityConfirm) {
                    _locationAbilities.Remove(pair.Key);
                    break;
                }
            }
        }

        Refresh();
    }

    public void RemoveAbility(
        Action onAbilityClick = null, 
        Action<GameObject[]> onAbilityConfirm = null
    ) {
        if (onAbilityClick != null) {
            if(!_objectAbilities.Remove(onAbilityClick)) {
                throw new ArgumentException(
                    onAbilityConfirm.Method.Name + " not present on subject."
                );
            }
        }
        else if (onAbilityConfirm != null) {
            foreach (
                KeyValuePair<Action, Action<GameObject[]>> pair in _objectAbilities
            ) {
                if (pair.Value == onAbilityConfirm) {
                    _locationAbilities.Remove(pair.Key);
                    break;
                }
            }
        }

        Refresh();
    }

    public void RemoveAllSelfAbilities() {
        _selfAbilities = new List<Action>();
        Refresh();
    }

    public void RemoveAllLocationAbilities() {
        _locationAbilities = new Dictionary<Action, Action<Vector3>>();
        Refresh();
    }

    public void RemoveAllGameObjectAbilities() {
        _objectAbilities = new Dictionary<Action, Action<GameObject[]>>();
        Refresh();
    }

    // ~~ private
    private void HandleDataChanged(IViewData data) {
        Refresh();
    }

    private IEnumerator WaitForClickLocation(Action<Vector3> ability) {
        while (!Input.GetKeyDown(KeyCode.Mouse0)) {
            yield return null;
        }
        
        ability(ScreenPoint.GetWorldPosition(Camera.main, Input.mousePosition));
    }

    private IEnumerator WaitForClickObject(Action<GameObject[]> ability) {
        Debug.Log("waiting for obj click");
        while (!Input.GetKeyDown(KeyCode.Mouse0)) {
            yield return null;
        }
        
        ability(ScreenPoint.GetObjectsUnder(Camera.main, Input.mousePosition));
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