using System;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public event Action<int> Changed;

    [SerializeField] private ItemsMatchFind _matchFind;

    private int _value;

    public int Value => _value;

    private void Awake()
    {
        Changed?.Invoke(_value);

        _matchFind.Finded += (_) => Increase();
    }

    private void Increase()
    {
        _value++;
        Changed?.Invoke(_value);
    }

    private void OnDestroy()
    {
        _matchFind.Finded -= (_) => Increase();
    }
}