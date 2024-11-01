using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private int _duration = 120;
    private bool _canRun = false;
    private float _value = 0f;

    public int Value
    {
        get { return (int)_value; }
    }

    public UnityEvent OnTimerStart = new UnityEvent();
    public UnityEvent OnTimerComplete = new UnityEvent();

    private void Update()
    {
        if (_canRun)
        {
            // update the timer
            _value -= Time.deltaTime;
            if (_value <= 0)
            {
                StopTimer();
            }
        }
    }

    public void StartTimer()
    {
        _value = _duration;
        _canRun = true;

        OnTimerStart.Invoke();
    }
    public void StartTimer(int duration)
    {
        _duration = duration;

        StartTimer();
    }
    public void StopTimer()
    {
        _canRun = false;
        _value = 0;

        OnTimerComplete.Invoke();
    }
}
