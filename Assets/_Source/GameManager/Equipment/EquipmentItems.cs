using UnityEngine;

public abstract class EquipmentItems :ScriptableObject
{
    public enumItemCategory ItemCategory;
    public Sprite Icon;
    public int Strength;
    public int Agility;
    public int Intelligence;
    public int Cost;
}