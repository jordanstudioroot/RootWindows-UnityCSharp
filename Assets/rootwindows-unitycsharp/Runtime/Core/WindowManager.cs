using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{   
    // FIELDS

    // ~ Static

    // ~~ public

    // ~~ private
    private static Canvas _canvas;

    // ~ Non-Static

    // ~~ public

    // ~~ private
    private const string RW_CANVAS_NAME = "RCanvas";
    private Dictionary<string, Subject> _subjects;

    // CONSTRUCTORS

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // DESTRUCTORS

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // DELEGATES

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // EVENTS

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

    // INTERFACES

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // PROPERTIES

    // ~ Static

    // ~~ public
    public static Canvas Canvas {
        get {
            if (_canvas == null) {
                throw new System.Exception("WindowManager has not instantiated the " + 
                "canvas, so it cannot be returned.");
            }

            return _canvas;
        }
    }    

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // INDEXERS

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // METHODS

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public
    public void Awake() {
        _subjects = new Dictionary<string, Subject>();
        _canvas = InititalizeCanvas();
   }

    public void Start()
    {
        
    }

    public void Register(string uniqueID, IViewData data) {
        Debug.Log("Registering " + uniqueID + " as data provider.\n");
        TryRegisterSubject(uniqueID, _subjects, data);
    }

    public void Register(
        string uniqueID,
        Action onAbilityClick,
        Action onAbilityConfirm
    ) {
        Debug.Log(
            "Registering " + uniqueID + " with ability " +
                onAbilityConfirm.Method.Name + ".\n");
        TryRegisterAbility(
            uniqueID,
            _subjects,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    public void Register(
        string uniqueID,
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    ) {
        Debug.Log(
            "Registering " + uniqueID + " with ability " +
                onAbilityConfirm.Method.Name + ".\n");
        TryRegisterAbility(
            uniqueID, 
            _subjects, 
            onAbilityClick, 
            onAbilityConfirm
        );
    }

    public void Register(
        string uniqueID,
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    ) {
        Debug.Log("Registering " + uniqueID + " with ability " + onAbilityConfirm.Method.Name + ".\n");
        TryRegisterAbility(
            uniqueID, 
            _subjects, 
            onAbilityClick, 
            onAbilityConfirm
        );
    }

    public void Deregister<T>(string uniqueID, T data) where T : IViewData {
        Debug.Log("Deregistering data on " + uniqueID + ".");
        TryDeregisterData<T>(_subjects[uniqueID], data);
        // if no data or abilities, destroy GameObject
    }

    public void Deregister(
        string uniqueID,
        Action onAbilityClick,
        Action onAbilityConfirm
    ) {
        Debug.Log(
            "Deregistering " + onAbilityConfirm.Method.Name + " on " + uniqueID + ".");
            
        TryDeregisterAbility(_subjects[uniqueID], onAbilityConfirm);
        // if no data or abilities, destroy GameObject
    }

    public void Deregister(
        string uniqueID,
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    ) {
        Debug.Log("Deregistering " + onAbilityConfirm.Method.Name + " on " + uniqueID + ".");
        TryDeregisterAbility(
            _subjects[uniqueID],
            onAbilityClick,
            onAbilityConfirm
        );
        // if no data or abilities, destroy GameObject
    }

    public void Deregister(
        string uniqueID,
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    ) {
        Debug.Log("Deregistering " + onAbilityConfirm.Method.Name + " on " + uniqueID + ".");
        TryDeregisterAbility(
            _subjects[uniqueID],
            onAbilityClick,
            onAbilityConfirm
        );
        // if no data or abilities, destroy GameObject
    }

    public ISubject GetSubject(string uniqueID) {
        if (_subjects.ContainsKey(uniqueID)) {
            return _subjects[uniqueID];
        }
        else {
            throw new System.ArgumentException("No such subject.");
        }       
    }

    public void HideAllSubjectViews() {
        foreach (KeyValuePair<string, Subject> pair in _subjects) {
            pair.Value.HideDetail();
            pair.Value.HideTooltip();
        }
    }

    public string SetBGColor(string uniqueID, Color bgColor) {
        if (_subjects.ContainsKey(uniqueID)) {
            Subject subject = _subjects[uniqueID];
            subject.SetBGColor(bgColor);
            return "success";
        }
        return "failure";
    }

    // ~~ private
    private void TryRegisterSubject<T>(
        string uniqueID, 
        Dictionary<string, Subject> subjects,
        T data
    ) where T : IViewData {
        if (subjects.ContainsKey(uniqueID)) {
            if (subjects[uniqueID] == null) {
                subjects[uniqueID] = new Subject(Canvas);
                TryRegisterData<T>(subjects[uniqueID], data);
            }
            else {
                TryRegisterData<T>(subjects[uniqueID], data);
            }
        }
        else {
            subjects.Add(uniqueID, new Subject(Canvas));
            TryRegisterData<T>(subjects[uniqueID], data);
        }
    }

    private Canvas InititalizeCanvas() {
        GameObject resultObj = new GameObject(RW_CANVAS_NAME);

        Canvas result = resultObj.AddComponent<Canvas>();
        result.renderMode = RenderMode.ScreenSpaceOverlay;

        resultObj.AddComponent<CanvasScaler>();
        resultObj.AddComponent<GraphicRaycaster>();
 
        return result;
    }

    private void TryRegisterData<T>(Subject subject, T data) where T : IViewData {
        subject.TryAddData(data);
    }

    private void TryDeregisterData<T>(Subject subject, T data) where T : IViewData {
        subject.TryRemoveData(data);
    }

    private void TryRegisterAbility(
        string uniqueID,
        Dictionary<string, Subject> subjects,
        Action onAbilityClick,
        Action onAbilityConfirm
    ) {
        if (subjects.ContainsKey(uniqueID)) {
            if (subjects[uniqueID] == null) {
                subjects[uniqueID] = new Subject(Canvas);
                subjects[uniqueID].TryAddAbility(
                    onAbilityClick,
                    onAbilityConfirm
                );
            }
            else {
                subjects[uniqueID].TryAddAbility(
                    onAbilityClick,
                    onAbilityConfirm
                );
            }
        }
        else {
            subjects.Add(uniqueID, new Subject(Canvas));
            subjects[uniqueID].TryAddAbility(
                onAbilityClick,
                onAbilityConfirm
            );
        }
    }

    private void TryRegisterAbility(
        string uniqueID,
        Dictionary<string, Subject> subjects,
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    ) {
        if (subjects.ContainsKey(uniqueID)) {
            if (subjects[uniqueID] == null) {
                subjects[uniqueID] = new Subject(Canvas);
                subjects[uniqueID].TryAddAbility(
                    onAbilityClick, 
                    onAbilityConfirm
                );
            }
            else {
                subjects[uniqueID].TryAddAbility(
                    onAbilityClick,
                    onAbilityConfirm
                );
            }
        }
        else {
            subjects.Add(uniqueID, new Subject(Canvas));
            subjects[uniqueID].TryAddAbility(
                onAbilityClick,
                onAbilityConfirm
            );
        }
    }

    private void TryRegisterAbility(
        string uniqueID,
        Dictionary<string, Subject> subjects,
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    ) {
        if (subjects.ContainsKey(uniqueID)) {
            if (subjects[uniqueID] == null) {
                subjects[uniqueID] = new Subject(Canvas);
                subjects[uniqueID].AddAbility(
                    onAbilityClick,
                    onAbilityConfirm
                );
            }
            else {
                subjects[uniqueID].AddAbility(
                    onAbilityClick,
                    onAbilityConfirm
                );
            }
        }
        else {
            subjects.Add(uniqueID, new Subject(Canvas));
            subjects[uniqueID].AddAbility(
                onAbilityClick,
                onAbilityConfirm
            );
        }
    }

    private void TryDeregisterAbility(
        Subject subject,
        Action ability = null
    ) {
        if (ability == null)
            subject.RemoveAllSelfAbilities();
        else
            subject.RemoveAbility(ability);
    }

    private void TryDeregisterAbility(
        Subject subject,
        Action onAbilityClick = null,
        Action<Vector3> onAbilityConfirm = null
    ) {
        if (onAbilityClick == null && onAbilityConfirm == null)
            subject.RemoveAllLocationAbilities();
        else    
            subject.RemoveAbility(
                onAbilityClick,
                onAbilityConfirm
            );
    }

    private void TryDeregisterAbility(
        Subject subject,
        Action onAbilityClick = null,
        Action<GameObject[]> onAbilityConfirm = null
    ) {
        if (onAbilityClick == null && onAbilityConfirm == null)
            subject.RemoveAllGameObjectAbilities();
        else
            subject.RemoveAbility(
                onAbilityClick,
                onAbilityConfirm
            );
    }
}
