using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemsMatchFind : MonoBehaviour
{
    public event Action<IEnumerable<Item>> Finded;

    [SerializeField] private ItemList _itemList;
    [SerializeField] [Min(2)] private int _minMatchCount = 3;

    private readonly IEnumerable<Vector2Int> Directions = new List<Vector2Int>
    {
        Vector2Int.left,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.up
    };

    private void Awake()
    {
        Item.Selected += TryFind;
    }

    private void TryFind(Item item)
    {
        var matches = new List<Item>();

        matches.AddRange(FindAllMatches(item));

        if (matches.Count() < _minMatchCount) return;

        Finded?.Invoke(matches);
    }

    public IEnumerable<Item> FindAllMatches(Item startItem)
    {
        var firstItems = FindAt(startItem);

        var allItems = new HashSet<Item>();

        for (int i = 0; i < firstItems.Count(); i++)
        {
            var item = firstItems.ElementAt(i);
            allItems.UnionWith(FindAt(item));
        }

        return allItems;
    }

    private IEnumerable<Item> FindAt(Item startItem)
    {
        var position = startItem.Position;
        var id = startItem.Id;
        var items = new HashSet<Item>();

        foreach (Vector2Int direction in Directions)
        {
            var item = startItem;
            var distance = 0;

            while (item != null)
            {
                if (item.Id != id) break;

                items.Add(item);

                distance++;
                _itemList.TryGetByPosition(position + direction * distance, out item);
            }
        }

        return items;
    }

    private void OnDestroy()
    {
        Item.Selected += TryFind;
    }
}