using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameSceneStateUI
{
    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI _tmpStrength;
    [SerializeField] private TextMeshProUGUI _tmpAgility;
    [SerializeField] private TextMeshProUGUI _tmpIntelligence;
    [Header("Items")]
    [SerializeField] private Image _imgHead;
    [SerializeField] private Image _imgBody;
    [SerializeField] private Image _imgHand;
    [SerializeField] private Image _imgLegs;
    [Header("Gold")]
    [SerializeField] private TextMeshProUGUI _tmpGold;
    public void Init()
    {
        Bind();
    }
    private void Bind()
    {
        GameManager.Instance.Events.EquipItem.Subscribe(UpdateUI);
        GameManager.Instance.Events.GoldValueChange.Subscribe(SetGold);
    }
    private void UpdateUI()
    {
        SetStats();
        SetImg();
        SetGold();
    }
    private void SetStats()
    {
        _tmpStrength.text = GameManager.Instance.Progress.GetStrength.ToString();
        _tmpAgility.text = GameManager.Instance.Progress.GetAgility.ToString();
        _tmpIntelligence.text = GameManager.Instance.Progress.GetIntelligence.ToString();
    }
    private void SetImg()
    {
        foreach (var item in GameManager.Instance.Progress.Equipment.Items)
        {
            if(item != null)
                CheckItemCategory(item);
        }
    }
    private void CheckItemCategory(EquipmentItems item)
    {
        Image temp = null;
        switch (item.ItemCategory)
        {
            case enumItemCategory.Head:
                temp = _imgHead;
                break;
            case enumItemCategory.Body:
                temp = _imgBody;
                break;
            case enumItemCategory.Legs:
                temp = _imgLegs;
                break;
            case enumItemCategory.Hand:
                temp = _imgHand;
                break;
            default:
                break;
        }
        temp.sprite = item.Icon;
        temp.gameObject.SetActive(true);
    }
    private void SetGold()
    {
        _tmpGold.text = GameManager.Instance.Progress.GoldValue.ToString();
    }
}
