using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class RootWindows : MonoBehaviour {
// FIELDS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    private WindowManager _windowManager;

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
    public delegate ISubject SubjectDelegate(string uniqueID);

// ~~ private
    private delegate void RegisterDataDelegate(
        string uniqueID, 
        IViewData data
    );

    private delegate void RegisterSelfAbilityDelegate(
        string uniqueID,
        Action onAbilityConfirm
    );

    private delegate void RegisterLocationAbilityDelegate(
        string uniqueID,
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    );

    private delegate void RegisterObjectAbilityDelegate(
        string uniqueID,
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    );

    private delegate void DeregisterDataDelegate(
        string uniqueID,
        IViewData data
    );

    private delegate void DeregisterSelfAbilityDelegate(
        string uniqueID,
        Action onAbilityConfirm = null
    );

    private delegate void DeregisterLocationAbilityDelegate(
        string uniqueID,
        Action onAbilityClick = null,
        Action<Vector3> onAbilityConfirm = null
    );

    private delegate void DeregisterObjectAbilityDelegate(
        string uniqueID,
        Action onAbilityClick = null,
        Action<GameObject[]> onAbilityConfirm = null
    );

// EVENTS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    private static event RegisterDataDelegate OnRegisterData;
    private static event RegisterSelfAbilityDelegate OnRegisterSelfAbility;
    private static event RegisterLocationAbilityDelegate OnRegisterLocationAbility;
    private static event RegisterObjectAbilityDelegate OnRegisterObjectAbility;
    private static event DeregisterDataDelegate OnDeregisterData;
    private static event DeregisterSelfAbilityDelegate OnDeregisterSelfAbility;
    private static event DeregisterLocationAbilityDelegate OnDeregisterLocationAbility;
    private static event DeregisterObjectAbilityDelegate OnDeregisterObjectAbility;
    private static event SubjectDelegate OnSubject;
// PROPERTIES

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// METHODS ~~~~~~~~~~

// ~ Static

// ~~ public
    public static void Register(string uniqueID, IViewData data) {
        if (OnRegisterData != null) {
            OnRegisterData(uniqueID, data);
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }        
    }

    public static void Register(string uniqueID, Action ability) {
        if (OnRegisterSelfAbility != null) {
            OnRegisterSelfAbility(uniqueID, ability);
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static void Register(
        string uniqueID, 
        Action onAbilityClick, 
        Action<GameObject[]> onAbilityConfirm
    ) {
        if (OnRegisterSelfAbility != null) {
            OnRegisterObjectAbility(
                uniqueID, 
                onAbilityClick, 
                onAbilityConfirm
            );
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static void Register(
        string uniqueID, 
        Action onAbilityClick, 
        Action<Vector3> onAbilityConfirm
    ) {
        if (OnRegisterSelfAbility != null) {
            OnRegisterLocationAbility(
                uniqueID, 
                onAbilityClick,
                onAbilityConfirm
            );
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static void Deregister(string uniqueID, IViewData data) {
        if (OnDeregisterData != null) {
            OnDeregisterData(uniqueID, data);
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static void Deregister(string uniqueID, Action onAbilityConfirm) {
        if (OnDeregisterSelfAbility != null) {
            OnDeregisterSelfAbility(uniqueID, onAbilityConfirm);
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static void Deregister(
        string uniqueID,
        Action onAbilityClick = null,
        Action<Vector3> onAbilityConfirm = null
    ) {
        if (OnDeregisterSelfAbility != null) {
            OnDeregisterLocationAbility(
                uniqueID,
                onAbilityClick,
                onAbilityConfirm
            );
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static void Deregister(
        string uniqueID,
        Action onAbilityClick = null,
        Action<GameObject[]> onAbilityConfirm = null
    ) {
        if (OnDeregisterSelfAbility != null) {
            OnDeregisterObjectAbility(
                uniqueID,
                onAbilityClick,
                onAbilityConfirm
            );
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

    public static ISubject Subject(string uniqueID) {
        if (OnSubject != null) {
            return OnSubject(uniqueID);
        }
        else {
            throw new System.Exception(
                "No listeners."
            );
        }
    }

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    private void Awake() { 
        if (!GameObject.FindObjectOfType<EventSystem>()) {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<BaseInputModule>();
        }
        gameObject.name = "Root Windows";

        _windowManager = gameObject.AddComponent<WindowManager>();

        Debug.Log("Subscribing WindowManager to RootWindows events.");
        OnRegisterData += HandleRegisterData;
        OnDeregisterData += HandleDeregisterData;
        OnRegisterSelfAbility += HandleRegisterSelfAbility;
        OnRegisterLocationAbility += HandleRegisterLocationAbility;
        OnRegisterObjectAbility += HandleRegisterObjectAbility;
        OnDeregisterSelfAbility += HandleDeregisterSelfAbility;
        OnDeregisterLocationAbility += HandleDeregisterLocationAbility;
        OnDeregisterObjectAbility += HandleDeregisterObjectAbility;
        OnSubject += HandleGetSubject;
    }

    private void HandleRegisterData(string uniqueID, IViewData data) {
        _windowManager.Register(uniqueID, data);
    }

    private void HandleRegisterSelfAbility(string uniqueID, Action onAbilityConfirm) {
        _windowManager.Register(uniqueID, onAbilityConfirm);
    }

    private void HandleRegisterLocationAbility(
        string uniqueID, 
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    ) {
        _windowManager.Register(
            uniqueID, 
            onAbilityClick, 
            onAbilityConfirm
        );
    }

    private void HandleRegisterObjectAbility(
        string uniqueID,
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    ) {
        _windowManager.Register(
            uniqueID,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    private void HandleDeregisterData(string uniqueID, IViewData data) {
        _windowManager.Deregister(uniqueID, data);
    }

    private void HandleDeregisterSelfAbility(string uniqueID, Action ability) {
        _windowManager.Deregister(uniqueID, ability);
    }

    private void HandleDeregisterLocationAbility(
        string uniqueID,
        Action onAbilityClick = null,
        Action<Vector3> onAbilityConfirm = null
    ) {
        _windowManager.Deregister(
            uniqueID,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    private void HandleDeregisterObjectAbility(
        string uniqueID,
        Action onAbilityClick = null,
        Action<GameObject[]> onAbilityConfirm = null
    ) {
        _windowManager.Deregister(
            uniqueID,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    private ISubject HandleGetSubject(string uniqueID) {
        return _windowManager.GetSubject(uniqueID);
    }
}