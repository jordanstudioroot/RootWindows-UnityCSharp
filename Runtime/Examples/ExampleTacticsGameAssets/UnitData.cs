using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UnitAttributes")]
public class UnitData : ScriptableObject
{
    public float HP;
    public float AP;
    public string description;
}
