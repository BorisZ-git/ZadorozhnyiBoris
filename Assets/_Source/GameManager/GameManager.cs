using UnityEngine;
[RequireComponent(typeof(GameTimer))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public EquipmentData Equipment { get => _equipmentData; }
    [SerializeField] private EquipmentData _equipmentData;
    public PlayerProgress Progress { get => _progress; }
    private PlayerProgress _progress;
    public EventManager Events { get => _events; }
    private EventManager _events;
    public GameTimer Timer { get => _timer; }
    private GameTimer _timer;
    private void Awake()
    {
        if(!Singltone()) return; // не выполнять дальше если объект существует
        InitComps();
        GetComps();
    }
    private void GetComps()
    {
        _timer = GetComponent<GameTimer>();
    }
    private void InitComps()
    {
        _events = new EventManager();
        _progress = new PlayerProgress();
        _equipmentData.Init();
    }
    private bool Singltone()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return true;
        }
        else
        {
            Destroy(gameObject);
            return false;
        }
    }
}