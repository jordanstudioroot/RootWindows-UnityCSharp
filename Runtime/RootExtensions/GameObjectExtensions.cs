using UnityEngine;

public static class GameObjectExtensions {
    public static void SetParent(this GameObject thisObj, GameObject otherObj, bool worldPositionStays) {
        thisObj.transform.SetParent(otherObj.transform, worldPositionStays);
    }

    public static void SetParent(this GameObject thisObj, Transform otherTransform, bool worldPositionStays) {
        thisObj.transform.SetParent(otherTransform, worldPositionStays);
    }    
}