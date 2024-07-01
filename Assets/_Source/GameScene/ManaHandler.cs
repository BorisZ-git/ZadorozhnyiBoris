using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ManaHandler
{
    [Header("Mana Line")]
    [SerializeField] private TextMeshProUGUI _tmpTimeValue;
    [SerializeField] private TextMeshProUGUI _tmpManaValue;
    [Header("Button Use Mana")]
    [SerializeField] private Button _btnUseMana;
    public void Init()
    {
        Bind();
        InitUpdateUI();
    }
    private void Bind()
    {
        // таймер
        GameManager.Instance.Events.TimeLeft.Subscribe(UpdateTimer);
        // изменение маны
        GameManager.Instance.Events.ManaValueChange.Subscribe(SetBtnInteract);
        GameManager.Instance.Events.ManaValueChange.Subscribe(UpdateManaValue);

    }
    public void Untying()
    {
        // таймер
        GameManager.Instance.Events.TimeLeft.Unscribe(UpdateTimer);
        // изменение маны
        GameManager.Instance.Events.ManaValueChange.Unscribe(SetBtnInteract);
        GameManager.Instance.Events.ManaValueChange.Unscribe(UpdateManaValue);
    }
    private void InitUpdateUI()
    {
        UpdateManaValue();
        SetBtnInteract();
    }
    private void UpdateManaValue()
    {
        _tmpManaValue.text = GameManager.Instance.Progress.ManaValue.ToString();
    }
    private void SetBtnInteract()
    {
        if (GameManager.Instance.Progress.ManaValue > 0)
            _btnUseMana.interactable = true;
        else
            _btnUseMana.interactable = false;
    }
    private void UpdateTimer(float value)
    {
        _tmpTimeValue.text = GetTimeFormat(value);
    }
    private string GetTimeFormat(float value)
    {
        int min = (int)(value / 60);
        int sec = (int)(value % 60);
        return $"{min:d2}:{sec:d2}";
    }
}
