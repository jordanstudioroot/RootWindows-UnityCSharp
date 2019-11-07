using UnityEngine;
using System.Collections.Generic;
// https://forum.unity.com/threads/quickly-retrieving-the-immediate-children-of-a-gameobject.39451/
// PutridPleasure response #5
public static class ComponentExtensions {
    public static T[] GetComponentsInDirectChildren<T>(this Component parent) 
    where T : Component {
        List<T> result = new List<T>();

        foreach (Transform t in parent.transform) {
            T component;
            if ((component = t.GetComponent<T>()) != null) {
                result.Add(component);
            }
        }

        return result.ToArray();
    }

    public static T[] GetComponentsInDirectChildrenExcept<Except, T>(this Component parent) {
        List<T> result = new List<T>();

        foreach (Transform t in parent.transform) {
            Except except;
            T component;
            if ((except = t.GetComponent<Except>()) == null &&
                (component = t.GetComponent<T>()) != null) {
                    result.Add(component);
            }
        }

        return result.ToArray();
    }
}