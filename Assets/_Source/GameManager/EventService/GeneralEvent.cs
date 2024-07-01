using System;

public class GeneralEvent
{
    public event Action EventAction;
    public void Subscribe(Action action)
    {
        EventAction += action;
    }
    public void Unscribe(Action action)
    {
        EventAction -= action;
    }
    public void OnEvent()
    {
        if (EventAction == null) return;
        EventAction();
    }
}
