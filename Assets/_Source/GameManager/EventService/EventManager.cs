public class EventManager
{
    /// <summary>
    /// ������� ��� ����������� ��������� �������� ����
    /// </summary>
    public GeneralEvent ManaValueChange { get => _manaValueChange; }
    private GeneralEvent _manaValueChange;
    /// <summary>
    /// ������� ��� ���������� ����
    /// </summary>
    public GeneralEvent FillMana { get => _fillMana; }
    private GeneralEvent _fillMana;
    /// <summary>
    /// ������� ����������� ����������� ����� �� ���������� ����
    /// </summary>
    public GeneralEventParam<float> TimeLeft { get => _timeLeft; }
    private GeneralEventParam<float> _timeLeft;
    /// <summary>
    /// ������� �� ������� ������ ��������� �����
    /// </summary>
    public GeneralEvent GenerateItem { get => _generateItem; }
    private GeneralEvent _generateItem;
    /// <summary>
    /// ������� ����� ��������� ������� ��� ���������� ����������
    /// </summary>
    public GeneralEvent EquipItem { get => _equipItem; }
    private GeneralEvent _equipItem;
    /// <summary>
    /// ������� ����� ���������� ������� ��� �������
    /// </summary>
    public GeneralEventParam<EquipmentItems> SellItem { get => _sellItem; }
    private GeneralEventParam<EquipmentItems> _sellItem;
    /// <summary>
    /// ������� ����� ���������� �������� �����
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
