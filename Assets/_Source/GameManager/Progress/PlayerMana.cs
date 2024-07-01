public class PlayerMana
{
    public int ManaValue { get => _manaValue; }
    private int _manaValue;
    public PlayerMana()
    {
        Bind();
    }
    private void Bind()
    {
        GameManager.Instance.Events.FillMana.Subscribe(IncreaseMana);
        GameManager.Instance.Events.GenerateItem.Subscribe(DecreaseMana);
    }
    private void IncreaseMana()
    {
        _manaValue++;
        GameManager.Instance.Events.ManaValueChange.OnEvent();
    }
    private void DecreaseMana()
    {
        _manaValue--;
        GameManager.Instance.Events.ManaValueChange.OnEvent();
    }
}
