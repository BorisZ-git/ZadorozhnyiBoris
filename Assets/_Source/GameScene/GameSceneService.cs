using UnityEngine;

public class GameSceneService : MonoBehaviour
{
    [SerializeField] private ManaHandler _manaHandler;
    [SerializeField] private GameSceneStateUI _stats;
    [SerializeField] private GenerateItemHandler _generateItemHandler;
    private void Awake()
    {
        _manaHandler.Init();
        GameManager.Instance.Timer.InitTimer();
        _generateItemHandler.Init();
        _stats.Init();
    }
    private void OnDestroy()
    {
        //GameManager.Instance.Timer.StopTimer();
        _manaHandler.Untying();
    }
    public void OnUseMana()
    {
        GameManager.Instance.Events.GenerateItem.OnEvent();
    }
    public void OnEquipBtn()
    {
        _generateItemHandler.EquipItem();
        _generateItemHandler.CloseWnd();
    }
    public void OnSellBtn()
    {
        _generateItemHandler.SellItem();
        _generateItemHandler.CloseWnd();
    }
}


