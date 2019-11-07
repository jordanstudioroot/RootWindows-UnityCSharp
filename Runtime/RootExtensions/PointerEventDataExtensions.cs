using UnityEngine;
using UnityEngine.EventSystems;

public static class PointerEventDataExtensions {
    public static Vector2 DeltaPosition(this PointerEventData pData, Vector2 position) {
        return new Vector2(
            Mathf.Abs(pData.position.x - position.x),
            Mathf.Abs(pData.position.y - position.y)
        );
    }

    public static bool IsNorthOf(this PointerEventData pData, Vector2 position) {
        return pData.position.y > position.y ? true : false;
    }

    public static bool IsEastOf(this PointerEventData pData, Vector2 position) {
        return pData.position.x > position.x ? true : false;
    }

    public static bool IsOnScreen(this PointerEventData pData) {
        if (pData.position.x > Screen.width ||
            pData.position.y > Screen.height ||
            pData.position.x < 0f ||
            pData.position.y < 0f
        ) {
            return false;
        }

        return true;
    }
}