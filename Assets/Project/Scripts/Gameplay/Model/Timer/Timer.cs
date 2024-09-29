using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int Second = 1;

    public event Action Expired;
    public event Action<int> Updated;

    [SerializeField] [Min(1)] private int _time = 90;

    private int _value;

    public int Value => _value;

    private IEnumerator Start()
    {
        _value = _time;

        Updated?.Invoke(_value);

        var wait = new WaitForSeconds(Second);

        while(_value > 0)
        {
            yield return wait;
            Decrease();
        }

        Expired?.Invoke();
    }

    public void Decrease()
    {
        Updated?.Invoke(--_value);
    }
}