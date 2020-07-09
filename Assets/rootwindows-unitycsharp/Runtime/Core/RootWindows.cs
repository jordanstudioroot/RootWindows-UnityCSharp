using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using RootEvents;
using RootUtils.Assets;
using RootUtils.Validation;
using RootLogging;

public class RootWindows : MonoBehaviour {
// FIELDS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private
    private static RootEvent<string, ISubject> _subjectEvent;
    private static RootEvent<string, IViewData, string> 
        _registerDataEvent;
    private static RootEvent<string, Action, Action, string> 
        _registerSelfAbilityEvent;
    private static RootEvent<string, Action, Action<Vector3>, string> 
        _registerLocationAbilityEvent;
    private static RootEvent<string, Action, Action<GameObject[]>, string>
        _registerObjectAbilityEvent;
    private static RootEvent<string, IViewData, string>
        _deregisterDataEvent;
    private static RootEvent<string, Action, Action, string>
        _deregisterSelfAbilityEvent;
    private static RootEvent<string, Action, Action<Vector3>, string>
        _deregisterLocationAbilityEvent;
    private static RootEvent<string, Action, Action<GameObject[]>, string>
        _deregisterObjectAbilityEvent;

    private static RootEvent<string, Color, string> _setBGColorEvent;

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

// ~~ private

// EVENTS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

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
    public static void RegisterViewData(string uniqueID, IViewData data) {
        _registerDataEvent.Publish(null, uniqueID, data);
    }

    public static void RegisterSelfAbility(
        string uniqueID,
        Action onAbilityClick,
        Action onAbility
    ) {
        _registerSelfAbilityEvent.Publish(
            null, 
            uniqueID, 
            onAbilityClick, 
            onAbility
        );
    }

    public static void RegisterLocationAbility(
        string uniqueID, 
        Action onAbilityClick, 
        Action<Vector3> onAbility
    ) {
        _registerLocationAbilityEvent.Publish(
            null,
            uniqueID,
            onAbilityClick,
            onAbility
        );
    }

    public static void RegisterObjectAbility(
        string uniqueID,
        Action onAbilityClick,
        Action<GameObject[]> onAbility
    ) {
        _registerObjectAbilityEvent.Publish(
            null,
            uniqueID,
            onAbilityClick,
            onAbility
        );
    }

    public static void DeregisterViewData(string uniqueID, IViewData data) {
        _deregisterDataEvent.Publish(
            null,
            uniqueID,
            data
        );
    }

    public static void DeregisterSelfAbility(
        string uniqueID,
        Action onAbilityClick,
        Action onAbilityConfirm
    ) {
        _deregisterSelfAbilityEvent.Publish(
            null,
            uniqueID,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    public static void DeregisterLocationAbility(
        string uniqueID,
        Action onAbilityClick,
        Action<Vector3> onAbilityConfirm
    ) {
        _deregisterLocationAbilityEvent.Publish(
            null,
            uniqueID,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    public static void DeregisterObjectAbility(
        string uniqueID,
        Action onAbilityClick,
        Action<GameObject[]> onAbilityConfirm
    ) {
        _deregisterObjectAbilityEvent.Publish(
            null,
            uniqueID,
            onAbilityClick,
            onAbilityConfirm
        );
    }

    public static ISubject Subject(string uniqueID) {
        CustomEventArgs<string, ISubject> args =
            _subjectEvent.Publish(
                null,
                uniqueID
            );
            
        return args.Response;
    }

    public static void SetBGColor(
        string uniqueID,
        Color bgColor
    ){
        _setBGColorEvent.Publish(
            null,
            uniqueID,
            bgColor
        );
    }

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    private void Awake() {
        if (!InstanceValidation.SingleInstanceExists<EventSystem>()) {
            RootLog.Log(
                "No event system.",
                Severity.Warning
            );
        }

        gameObject.name = "Root Windows";

        _windowManager = gameObject.AddComponent<WindowManager>();
        Debug.Log("Subscribing WindowManager to RootWindows events.");

        _subjectEvent = new RootEvent<string, ISubject>();

        _registerDataEvent = 
            new RootEvent<string, IViewData, string>();
        _registerSelfAbilityEvent = 
            new RootEvent<string, Action, Action, string>();
        _registerLocationAbilityEvent = 
            new RootEvent<string, Action, Action<Vector3>, string>();
        _registerObjectAbilityEvent = 
            new RootEvent<string, Action, Action<GameObject[]>, string>();

        _deregisterDataEvent =
            new RootEvent<string, IViewData, string>();
        _deregisterSelfAbilityEvent =
            new RootEvent<string, Action, Action, string>();
        _deregisterLocationAbilityEvent =
            new RootEvent<string, Action, Action<Vector3>, string>();
        _deregisterObjectAbilityEvent =
            new RootEvent<string, Action, Action<GameObject[]>, string>();

        _setBGColorEvent = new RootEvent<string, Color, string>();

        _subjectEvent.Subscribe(HandleSubject);

        _registerDataEvent.Subscribe(HandleRegisterData);
        _registerSelfAbilityEvent.Subscribe(HandleRegisterSelfAbility);
        _registerLocationAbilityEvent.Subscribe(HandleRegisterLocationAbility);
        _registerObjectAbilityEvent.Subscribe(HandleRegisterObjectAbility);

        _deregisterDataEvent.Subscribe(HandleDeregisterData);
        _deregisterSelfAbilityEvent.Subscribe(HandleDeregisterSelfAbility);
        _deregisterLocationAbilityEvent.Subscribe(HandleDeregisterLocationAbility);
        _deregisterObjectAbilityEvent.Subscribe(HandleDeregisterObjectAbility);

        _setBGColorEvent.Subscribe(HandleSetBGColor);
    }

    private void HandleRegisterData(
        object source, 
        CustomEventArgs<string, IViewData, string> args
    ) {
        _windowManager.Register(args.Argument1, args.Argument2);
        args.Response = args.Argument1 + " registered view data.";
    }

    private void HandleRegisterSelfAbility(
        object source,
        CustomEventArgs<string, Action, Action, string> args
    ) {
        _windowManager.Register(args.Argument1, args.Argument2, args.Argument3);
        args.Response = args.Argument1 + " registered self ability.";
    }

    private void HandleRegisterLocationAbility(
        object source,
        CustomEventArgs<string, Action, Action<Vector3>, string> args
    ) {
        _windowManager.Register(args.Argument1, args.Argument2, args.Argument3);
        args.Response = args.Argument1 + " registered location ability.";
    }

    private void HandleRegisterObjectAbility(
        object source,
        CustomEventArgs<string, Action, Action<GameObject[]>, string> args
    ) {
        _windowManager.Register(args.Argument1, args.Argument2, args.Argument3);
        args.Response = args.Argument1 + " registered object ability.";
    }

    private void HandleDeregisterData(
        object source,
        CustomEventArgs<string, IViewData, string> args
    ) {
        _windowManager.Deregister(args.Argument1, args.Argument2);
    }

    private void HandleDeregisterSelfAbility(
        object source,
        CustomEventArgs<string, Action, Action, string> args
    ) {
        _windowManager.Deregister(args.Argument1, args.Argument2, args.Argument3);
    }

    private void HandleDeregisterLocationAbility(
        object source,
        CustomEventArgs<string, Action, Action<Vector3>, string> args
    ) {
        _windowManager.Deregister(
            args.Argument1,
            args.Argument2,
            args.Argument3
        );
    }

    private void HandleDeregisterObjectAbility(
        object source,
        CustomEventArgs<string, Action, Action<GameObject[]>, string> args
    ) {
        _windowManager.Deregister(
            args.Argument1,
            args.Argument2,
            args.Argument3
        );
    }

    private void HandleSubject(
        object source,
        CustomEventArgs<string, ISubject> args
    ) {
        args.Response = _windowManager.GetSubject(args.Argument);
    }

    private void HandleSetBGColor(
        object source,
        CustomEventArgs<string, Color, string> args
    ) {
        args.Response = _windowManager.SetBGColor(
            args.Argument1,
            args.Argument2
        );
    }
}