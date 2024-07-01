using System;

public class GeneralEventParam<T>
{
    public event Action<T> eventParam;
    public void Subscribe(Action<T> action)
    {
        eventParam += action;
    }
    public void Unscribe(Action<T> action)
    {
        eventParam -= action;
    }
    public void OnEvent(T param)
    {
        if (eventParam == null) return;
        eventParam(param);
    }
}
