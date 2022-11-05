using System;
using UnityEngine;
using UnityEngine.UI;

public class ApplyValues : MonoBehaviour
{
    public delegate void ApplySpawnTime(int time);
    public static event ApplySpawnTime spawnTimeApplied;

    [SerializeField] private Text _spawnTimeInput;
    [SerializeField] private Text _speedInput;
    [SerializeField] private Text _distanceInput;
    private static int _time;
    private static int _prevTime;
    private static int _speed;
    private static int _prevSpeed;
    private static int _distance;
    private static int _prevDistance;

    public void OnApply()
    {
        try
        {
            _prevTime = _time;
            _time = Convert.ToInt32(_spawnTimeInput.text);
            spawnTimeApplied?.Invoke(GetTime());
            _prevSpeed = _speed;
            _speed = Convert.ToInt32(_speedInput.text);
            _prevDistance = _distance;
            _distance = Convert.ToInt32(_distanceInput.text);
        }
        catch (FormatException)
        {
            ExceptionHandler.OnHaveFormatException();
        }
    }

    private int GetTime()
    {
        return GetValue(_time, _prevTime);
    }

    public static int GetSpeed()
    {
        return GetValue(_speed, _prevSpeed);
    }

    public static int GetDistance()
    {
        return GetValue(_distance, _prevDistance);
    }

    private static int GetValue(int a, int prevA)
    {
        if (ValueLessZero(a))
        {
            ExceptionHandler.OnHaveZeroValue();
            return prevA;
        }
        else
            return a;
    }

    private static bool ValueLessZero(int a)
    {
        return a <= 0;
    }
}