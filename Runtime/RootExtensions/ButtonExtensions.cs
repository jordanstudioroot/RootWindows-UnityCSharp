using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class ButtonExtensions {
//  https://gamedev.stackexchange.com/questions/92146/button-stays-highlighted-after-being-clicked-unity3d-4-6-gui
//  sonny, jul 26 '18
    public static void Deselect(this Button button) {
        if (EventSystem.current.currentSelectedGameObject && 
            EventSystem.current.currentSelectedGameObject == button.gameObject
        ) {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}