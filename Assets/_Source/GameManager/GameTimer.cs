using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _timeToFillMana;
    private float _time;
    public void InitTimer()
    {
        CheckTimer();
        StartCoroutine(CountTime());
    }
    public void StopTimer()
    {
        StopCoroutine(CountTime());
    }
    private IEnumerator CountTime() // отсчитывает время
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _time++;
            CheckTimer();
        }
    }
    private void CheckTimer() // проверка и вызов событий
    {
        if(_time >= _timeToFillMana)
        {
            GameManager.Instance.Events.FillMana.OnEvent(); 
            _time = 0;
        }
        GameManager.Instance.Events.TimeLeft.OnEvent(_timeToFillMana-_time); // отправим время
    }
}
