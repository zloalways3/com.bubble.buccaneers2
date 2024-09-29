using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemList : Initializable<IEnumerable<Item>>
{
    private List<Item> _items;

    public int Count => _items.Count;

    public Item GetByIndex(int index)
    {
        return _items[index];
    }

    public bool TryGetByPosition(Vector2Int position, out Item item)
    {
        item = null;

        bool Condition(Item item) => item.Position == position;

        if (!_items.Any(Condition)) return false;

        item = _items.FirstOrDefault(Condition);

        return item != null;
    }

    protected override void Initialize(IEnumerable<Item> items)
    {
        _items = new List<Item>(items);

        Item.Destroyed += Remove;
    }

    private void Remove(Item item)
    {
        if (!_items.Contains(item)) return;

        _items.Remove(item);
    }

    private void OnDestroy()
    {
        Item.Destroyed -= Remove;
    }
}