public class PlayerProgress
{
    public int ManaValue { get => _mana.ManaValue; }
    private PlayerMana _mana;
    public PlayerEquipment Equipment { get => _equip; }
    private PlayerEquipment _equip;

    private PlayerStats _stats;
    private PlayerGold _gold;

    public int GetStrength { get => _stats.Strength + _equip.Strength; }
    public int GetAgility { get => _stats.Agility + _equip.Agility; }
    public int GetIntelligence { get => _stats.Intelligence + _equip.Intelligence; }

    public PlayerProgress()
    {
        InitComps();
    }
    private void InitComps()
    {
        _mana = new PlayerMana();
        _gold = new PlayerGold();
        _equip = new PlayerEquipment();
        _stats = new PlayerStats();
    }
}