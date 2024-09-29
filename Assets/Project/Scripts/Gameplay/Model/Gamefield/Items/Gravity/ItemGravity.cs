using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemGravity : MonoBehaviour
{
    public event Action Falled;

    [SerializeField] private ItemsMatchFind _matchFinder;
    [SerializeField] private ItemList _itemList;

    [SerializeField][Min(0.1f)] private float _fallingDuration = 0.25f;
    [SerializeField] private AnimationCurve _fallingEase;

    private PureAnimation _animation;

    private void Awake()
    {
        _matchFinder.Finded += HandleFoundItems;
        _animation = new PureAnimation(this);
    }

    private void HandleFoundItems(IEnumerable<Item> items)
    {
        var above = FindItemsAbove(items);

        if (above.Count() <= 0) return;

        foreach (var item in above)
        {
            int x = item.Position.x;
            int y = item.Position.y;
            int distance = items.Where(i => i.Position.x == x && i.Position.y < y).Count();

            if (distance == 0) continue;

            item.MoveDown(distance);
            Fall(item, distance);
        }

        Falled?.Invoke();
    }

    private void Fall(Item item, int distance)
    {
        var transform = item.transform;
        var startPos = transform.position;
        var endPos = startPos + (Vector3.down * distance * item.Size.y);
        var step = endPos.y - startPos.y;

        _animation.Play(_fallingDuration, (progress) =>
        {
            var x = transform.position.x;
            var y = startPos.y + _fallingEase.Evaluate(progress) * step;

            transform.position = new Vector3(x, y);
        }, () => { transform.position = endPos; });
    }

    private IEnumerable<Item> FindItemsAbove(IEnumerable<Item> items)
    {
        var result = new HashSet<Item>();
        Vector2Int direction = Vector2Int.up;

        foreach (var item in items)
        {
            var targetItem = item;
            while (targetItem != null)
            {
                Vector2Int position = targetItem.Position;
                _itemList.TryGetByPosition(position + direction, out targetItem);

                if (targetItem != null && !items.Contains(targetItem))
                {
                    result.Add(targetItem);
                }
            }
        }

        return result;
    }

    private void OnDestroy()
    {
        _matchFinder.Finded -= HandleFoundItems;
    }
}