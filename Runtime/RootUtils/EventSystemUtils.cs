using UnityEngine;
using UnityEngine.EventSystems;
public static class EventSystemUtils {
    /// <summary>
    /// Attempts to create a new GameObject with an attched EventSystem
    /// if one does not already exist, and attaches a StandaloneInputModule.
    /// </summary>
    public static void TryInitEventSystem() {
        if (!GameObject.FindObjectOfType<EventSystem>()) {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }
}
