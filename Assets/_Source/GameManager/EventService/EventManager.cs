public class EventManager
{
    /// <summary>
    /// событие для отображения изменения значения маны
    /// </summary>
    public GeneralEvent ManaValueChange { get => _manaValueChange; }
    private GeneralEvent _manaValueChange;
    /// <summary>
    /// событие для пополнения маны
    /// </summary>
    public GeneralEvent FillMana { get => _fillMana; }
    private GeneralEvent _fillMana;
    /// <summary>
    /// событие отображения оставщегося время до пополнения маны
    /// </summary>
    public GeneralEventParam<float> TimeLeft { get => _timeLeft; }
    private GeneralEventParam<float> _timeLeft;
    /// <summary>
    /// событие по нажатию кнопки генерации итема
    /// </summary>
    public GeneralEvent GenerateItem { get => _generateItem; }
    private GeneralEvent _generateItem;
    /// <summary>
    /// событие когда одевается предмет для обновления параметров
    /// </summary>
    public GeneralEvent EquipItem { get => _equipItem; }
    private GeneralEvent _equipItem;
    /// <summary>
    /// событие когда передается предмет для продажи
    /// </summary>
    public GeneralEventParam<EquipmentItems> SellItem { get => _sellItem; }
    private GeneralEventParam<EquipmentItems> _sellItem;
    /// <summary>
    /// событие когда изменилось значение денег
    /// </summary>
    public GeneralEvent GoldValueChange { get => _goldValueChange; }
    private GeneralEvent _goldValueChange;
    public EventManager()
    {
        _manaValueChange = new GeneralEvent();
        _fillMana = new GeneralEvent();
        _generateItem = new GeneralEvent();
        _equipItem = new GeneralEvent();
        _goldValueChange = new GeneralEvent();
        _timeLeft = new GeneralEventParam<float>();
        _sellItem = new GeneralEventParam<EquipmentItems>();
    }
}
