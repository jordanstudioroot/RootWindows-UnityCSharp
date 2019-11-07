 using UnityEngine;
 public static class RectTransformExtensions
 {
    public static void Left(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void Right(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void Top(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void Bottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }

    public static bool IsNorthOf(this RectTransform rt, RectTransform other) { 
        if (rt.position.y > other.position.y) {
            return true;
        }

        return false;      
    }

    public static bool IsEastOf(this RectTransform rt, RectTransform other) {
        if (rt.position.y > other.position.y) {
            return true;
        }

        return false;
    }

    public static bool IsNorthOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.y > rt.parent.transform.position.y) {
            return true;
        }

        return false;
    }

    public static bool IsSouthOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.y < rt.parent.transform.position.y) {
            return true;
        }

        return false;
    }

    public static bool IsEastOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.x > rt.parent.transform.position.y) {
            return true;
        }

        return false;
    }

    public static bool IsWestOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.x < rt.parent.transform.position.x) {
            return true;
        }

        return false;
    }

    public static bool IsNorthwestOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.x > rt.parent.transform.position.x &&
            rt.transform.position.y > rt.parent.transform.position.y
        ) {
                return true;
        }

        return false;
    }

    public static bool IsSouthwestOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.x > rt.parent.transform.position.x &&
            rt.transform.position.y < rt.parent.transform.position.y
        ) {
            return true;
        }

        return false;
    }

    public static bool IsSoutheastOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.x < rt.parent.transform.position.x &&
            rt.transform.position.y < rt.parent.transform.position.y
        ) {
            return true;
        }

        return false;
    }

    public static bool IsNortheastOfParent(this RectTransform rt) {
        if (rt.parent == null) {
            return false;
        }

        if (rt.transform.position.x < rt.parent.transform.position.x &&
            rt.transform.position.y > rt.parent.transform.position.y
        ) {
            return true;
        }
        
        return false;
    }
 }