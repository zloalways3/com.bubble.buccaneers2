using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    [SerializeField] private ItemsMatchFind _matchFind;

    private void Awake()
    {
        _matchFind.Finded += Destroy;
    }

    private void Destroy(IEnumerable<Item> items)
    {
        foreach(var item in items)
        {
            item.TryDestroy();
        }
    }

    private void OnDestroy()
    {
        _matchFind.Finded -= Destroy;
    }
}