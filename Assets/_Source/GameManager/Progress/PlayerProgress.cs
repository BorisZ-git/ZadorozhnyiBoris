public class PlayerProgress
{
    public PlayerEquipment Equipment { get => _equipment; }
    private PlayerEquipment _equipment;

    private PlayerMana _mana;
    private PlayerStats _stats;
    private PlayerGold _gold;
    public int ManaValue { get => _mana.ManaValue; }
    public int GoldValue { get => _gold.GoldValue; }
    public int GetStrength { get => _stats.Strength + _equipment.Strength; }
    public int GetAgility { get => _stats.Agility + _equipment.Agility; }
    public int GetIntelligence { get => _stats.Intelligence + _equipment.Intelligence; }

    public PlayerProgress()
    {
        _mana = new PlayerMana();
        _stats = new PlayerStats();
        _equipment = new PlayerEquipment();
        _gold = new PlayerGold();
    }
}