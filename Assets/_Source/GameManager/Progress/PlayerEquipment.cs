using System.Collections.Generic;
using System.Linq;

public class PlayerEquipment
{
    public List<EquipmentItems> Items { get => _items; }
    private List<EquipmentItems> _items;
    private HeadItem _headItem;
    private HandItem _handItem;
    private BodyItem _bodyItem;
    private LegsItem _legsItem;
    public int Strength { get => _strength; }
    private int _strength;
    public int Agility { get => _agility; }
    private int _agility;
    public int Intelligence { get => _intelligence; }
    private int _intelligence;
    public PlayerEquipment()
    {
        SetItemsList();
    }
    private void SetEquipmentStats()
    {
        foreach (var item in _items.Where(x => x != null))
        {
            _strength += item.Strength;
            _agility += item.Agility;
            _intelligence += item.Intelligence;
        }
    }
    private void SetItemsList()
    {
        _items = new List<EquipmentItems>();
        _items.Add(_headItem);
        _items.Add(_handItem);
        _items.Add(_bodyItem);
        _items.Add(_legsItem);
    }
    public EquipmentItems GetEquipmentItem(enumItemCategory itemCategory)
    {
        EquipmentItems equip = null;
        switch (itemCategory)
        {
            case enumItemCategory.Head:
                equip = _headItem;
                break;
            case enumItemCategory.Body:
                equip = _bodyItem;
                break;
            case enumItemCategory.Legs:
                equip = _legsItem;
                break;
            case enumItemCategory.Hand:
                equip = _handItem;
                break;
            default:
                equip = null;
                break;
        }
        return equip;
    }
    public void TryEquipItem(EquipmentItems newItem)
    {
        if(_items.Where(a => a != null).Select(x => x.ItemCategory).ToList().Contains(newItem.ItemCategory))
            ReplaceItem(newItem);
        else
            EquipItem(newItem);
        SetItemsList();
        SetEquipmentStats();
        GameManager.Instance.Events.EquipItem.OnEvent();
    }
    private void ReplaceItem(EquipmentItems newItem)
    {
        foreach (var item in _items)
        {
            if(item != null && item.ItemCategory == newItem.ItemCategory)
            {
                GameManager.Instance.Events.SellItem.OnEvent(item);
                break;
            }
        }
        EquipItem(newItem);
    }
    private void EquipItem(EquipmentItems newItem)
    {
        switch (newItem.ItemCategory)
        {
            case enumItemCategory.Head:
                _headItem = newItem as HeadItem;
                break;
            case enumItemCategory.Body:
                _bodyItem = newItem as BodyItem;
                break;
            case enumItemCategory.Legs:
                _legsItem = newItem as LegsItem;
                break;
            case enumItemCategory.Hand:
                _handItem = newItem as HandItem;
                break;
            default:
                break;
        }
    }
}
