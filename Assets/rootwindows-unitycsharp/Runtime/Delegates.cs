using UnityEngine;

public delegate void SelfAbilityDelegate();
public delegate void LocationAbilityDelegate(Vector3 pointerAt);
public delegate void ObjectAbilityDelegate(GameObject[] objectsUnderPointer);
public delegate void DataChangedDelegate(IViewData data);