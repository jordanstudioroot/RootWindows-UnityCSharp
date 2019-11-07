using System.Collections.Generic;
using UnityEngine;

public class AttributeData : IAttributeData {
    private Dictionary<string, float[]> _attributes;

    public Dictionary<string, float[]> AttributeDictionary {
        get {
            return _attributes;
        }
    }

    public AttributeData() {
        _attributes = new Dictionary<string, float[]>();
    }

    public void SetAttribute(string attribute, float value, float minValue = -1, float maxValue = -1) {
        if (_attributes.ContainsKey(attribute)) {
            _attributes[attribute] = new float[] {value, minValue, maxValue};
            if (OnDataChanged != null) {
                OnDataChanged(this);
            }
        }
        else {
            _attributes.Add(attribute, new float[] {value, minValue, maxValue});
            if (OnDataChanged != null) {
                OnDataChanged(this);
            }
        }
    }

    public void ChangeAttribute(string attribute, float magnitude) {
        if (_attributes.ContainsKey(attribute)) {
            float currentVal = _attributes[attribute][0];
            float minVal = _attributes[attribute][1];
            float maxVal = _attributes[attribute][2];

            if (minVal != -1) {
                if (currentVal + magnitude < minVal) {
                    throw new System.ArgumentException("New value would be outside range.");
                }
            }

            if (maxVal != -1) {
                if (currentVal + magnitude > maxVal) {
                    throw new System.ArgumentException("New value would be outside range.");
                }   
            }

            _attributes[attribute][0] = currentVal + magnitude;
            OnDataChanged(this);
        }
        else {
            throw new System.ArgumentException("No such attribute.");
        }
    }

    public float GetAttribute(string attribute) {
        if (_attributes.ContainsKey(attribute)) {
            return _attributes[attribute][0];
        }

        Debug.Log("No such attribute.");

        return 0;
    }

    public float GetAttributeMin(string attribute) {
        if (_attributes.ContainsKey(attribute)) {
           return _attributes[attribute][1];
        }

        Debug.Log("No such attribute.");

        return 0;
    }

    public float GetAttributeMax(string attribute) {
        if (_attributes.ContainsKey(attribute)) {
           return _attributes[attribute][2];
        }

        Debug.Log("No such attribute.");

        return 0;
    }

    public event DataChangedDelegate OnDataChanged;
}