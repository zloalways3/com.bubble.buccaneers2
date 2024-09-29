using System;
using UnityEngine;

public class GamefieldSetup : MonoBehaviour
{
    public event Action Initialized;

    [SerializeField] private ItemFactory _itemFactory;
    [SerializeField] private ItemList _itemList;

    private void Start()
    {
        var items = _itemFactory.Spawn();

        _itemList.TryInitialize(items);

        Initialized?.Invoke();
    }
}