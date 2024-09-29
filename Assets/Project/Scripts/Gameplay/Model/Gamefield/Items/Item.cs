using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Item : Initializable<Vector2Int>
{
    public static event Action<Item> Selected;
    public static event Action<Item> Destroyed;

    [SerializeField] private SpriteRenderer _renderer;
    
    private int _id;

    public Vector2Int Position { get; set; }

    public Vector2 Size => _renderer.size;
    public int Id => _id;

    private int MaxID => ItemViewVariants.Count;

    public void Select()
    {
        Selected?.Invoke(this);
    }

    public bool TryDestroy()
    {
        if (!gameObject.activeSelf) return false;

        gameObject.SetActive(false);
        Destroyed?.Invoke(this);

        return true;
    }

    public void MoveDown(int distance)
    {
        if (distance <= 0) return;

        var x = Position.x;
        var y = Position.y - distance;

        Position = new Vector2Int(x, y);
    }

    protected override void Initialize(Vector2Int position)
    {
        _id = Random.Range(0, MaxID);
        Position = position;
    }
}