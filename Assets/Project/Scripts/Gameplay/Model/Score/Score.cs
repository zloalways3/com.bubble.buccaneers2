using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action<int> Changed;

    [SerializeField] [Min(1)] int _scorePerItem = 50;
    [SerializeField] private ItemsMatchFind _matchFind;

    private int _value;

    public int Value => _value;

    private void Awake()
    {
        Changed?.Invoke(_value);

        _matchFind.Finded += Add;
    }

    private void Add(IEnumerable<Item> items)
    {
        var count = items.Count();

        _value += count * _scorePerItem;

        Changed?.Invoke(_value);
    }

    private void OnDestroy()
    {
        _matchFind.Finded -= Add;
    }
}