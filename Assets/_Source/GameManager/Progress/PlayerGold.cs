public class PlayerGold
{
    public int GoldValue { get => _goldValue; }
    private int _goldValue;
    public PlayerGold()
    {
        Bind();
    }
    private void Bind()
    {
        GameManager.Instance.Events.SellItem.Subscribe(SellItem);
    }
    private void SellItem(EquipmentItems item)
    {
        _goldValue += item.Cost;
        GameManager.Instance.Events.GoldValueChange.OnEvent();
    }
}
