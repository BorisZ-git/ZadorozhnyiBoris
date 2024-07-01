using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class GenerateItemHandler
{
    [Header("Window")]
    [SerializeField] private GameObject _generateWnd;
    [Header("OldItem")]
    [SerializeField] private Image _oldItemIcon;
    [SerializeField] private TextMeshProUGUI _tmpOldStrength;
    [SerializeField] private TextMeshProUGUI _tmpOldAgility;
    [SerializeField] private TextMeshProUGUI _tmpOldIntelligence;
    [SerializeField] private TextMeshProUGUI _tmpOldCost;
    [Header("NewItem")]
    [SerializeField] private Image _newItemIcon;
    [SerializeField] private TextMeshProUGUI _tmpNewStrength;
    [SerializeField] private TextMeshProUGUI _tmpNewAgility;
    [SerializeField] private TextMeshProUGUI _tmpNewIntelligence;
    [SerializeField] private TextMeshProUGUI _tmpNewCost;
    [Header("Buttons")]
    [SerializeField] private TextMeshProUGUI _tmpBtnReplace;
    [SerializeField] private string _strReplace;
    [SerializeField] private string _strEquip;
    private EquipmentItems _newItem;
    private EquipmentItems _oldItem;
    public void Init()
    {
        Bind();
    }
    private void Bind()
    {
        GameManager.Instance.Events.GenerateItem.Subscribe(OpenGenerateWnd);
    }
    private void SetOldItem()
    {
        _oldItemIcon.gameObject.SetActive(true);
        _oldItemIcon.sprite = _oldItem.Icon;
        _tmpOldStrength.text = _oldItem.Strength.ToString();
        _tmpOldAgility.text = _oldItem.Agility.ToString();
        _tmpOldIntelligence.text = _oldItem.Intelligence.ToString();
        _tmpOldCost.text = _oldItem.Cost.ToString();
    }
    private void SetNewItem()
    {
        _newItemIcon.sprite = _newItem.Icon;
        _tmpNewStrength.text = _newItem.Strength.ToString();
        _tmpNewAgility.text = _newItem.Agility.ToString();
        _tmpNewIntelligence.text = _newItem.Intelligence.ToString();
        _tmpNewCost.text = _newItem.Cost.ToString();
    }
    public void SellItem() => GameManager.Instance.Events.SellItem.OnEvent(_newItem);
    public void EquipItem() => GameManager.Instance.Progress.Equipment.TryEquipItem(_newItem);
    private void GetNewItem()
    {
        _newItem = GameManager.Instance.Equipment.GetRandomItem();
        SetNewItem();
    }
    private void GetOldItem()
    {
        _oldItem = GameManager.Instance.Progress.Equipment.GetEquipmentItem(_newItem.ItemCategory);
        if (_oldItem != null)
            SetOldItem();
        else
            ResetOldItem();
    }
    private void OpenGenerateWnd()
    {
        _generateWnd.gameObject.SetActive(true);
        GetNewItem();
        GetOldItem();
        SetReplaceBtnText();
    }
    private void SetReplaceBtnText()
    {
        if (_oldItem == null)
            _tmpBtnReplace.text = _strEquip;
        else
            _tmpBtnReplace.text = _strReplace;
    }
    public void CloseWnd()
    {
        _generateWnd.gameObject.SetActive(false);
        ResetItems();
    }
    private void ResetItems()
    {
        _oldItem = null;
        _newItem = null;
    }
    private void ResetOldItem()
    {
        _oldItemIcon.gameObject.SetActive(false);
        _oldItemIcon.sprite = null;
        _tmpOldStrength.text = "0";
        _tmpOldAgility.text = "0";
        _tmpOldIntelligence.text = "0";
        _tmpOldCost.text = "0";
    }
}
