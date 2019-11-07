using UnityEngine;

public static class ScreenPoint {
    public static bool IsOnScreen(Vector2 screenPoint) {
        if (
            screenPoint.x > Screen.width ||
            screenPoint.x < 0 ||
            screenPoint.y > Screen.height ||
            screenPoint.y < 0
        )
        {
            return false;
        }

        return true;
    }

    public static Vector3 GetWorldPosition(Camera camera, Vector2 screenPoint) {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPoint);
        
        if (Physics.Raycast(ray, out hit)) {
            return hit.point;
        }

        return Vector3.negativeInfinity;
    }

    public static GameObject GetObjectUnder(Camera camera, Vector2 screenPoint) {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPoint);
        
        if (Physics.Raycast(ray, out hit)) {
            return hit.transform.gameObject;
        }

        return null;
    }

    public static GameObject[] GetObjectsUnder(Camera camera, Vector2 screenPoint) {
        Ray ray = camera.ScreenPointToRay(screenPoint);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        GameObject[] result = new GameObject[hits.Length];

        for (int i = 0; i < hits.Length; i++) {
            result[i] = hits[i].transform.gameObject;
        }

        return result;
    }
}