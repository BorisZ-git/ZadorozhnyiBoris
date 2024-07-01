using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentData
{
    [SerializeField] List<HeadItem> _headItems;
    [SerializeField] List<HandItem> _handItems;
    [SerializeField] List<BodyItem> _bodyItems;
    [SerializeField] List<LegsItem> _legsItems;
    private List<EquipmentItems> _equipmentItems;
    public void Init()
    {
        _equipmentItems = new List<EquipmentItems>();
        _equipmentItems.AddRange(_headItems);
        _equipmentItems.AddRange(_handItems);
        _equipmentItems.AddRange(_bodyItems);
        _equipmentItems.AddRange(_legsItems);
    }
    public EquipmentItems GetRandomItem() 
    {
        int i = UnityEngine.Random.Range(0, _equipmentItems.Count);
        return _equipmentItems[i];
    }
}
