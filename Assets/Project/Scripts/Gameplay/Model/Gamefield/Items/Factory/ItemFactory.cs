using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : Factory<Item>
{
    [Header("Prefab Setup")]
    [SerializeField] private Item _prefab;
    [SerializeField] private Transform _parent;

    [Header("Generation Setup")]
    [SerializeField] [Min(1)] private int _width = 9;
    [SerializeField] [Min(1)] private int _maxHeight = 9;
    [SerializeField] [Min(1)] private int _heightOffset = 4;
    [SerializeField] [Min(0.01f)] private float _noiseMultiplier = 0.1f;

    protected override Transform Parent => _parent;

    public IEnumerable<Item> Spawn()
    {
        var shapeGen = new GamefieldShapeGenerator(_width, _maxHeight, _heightOffset, _noiseMultiplier);

        var shape = shapeGen.Generate();

        var minX = shape.MinX;
        var maxX = shape.MaxX;

        var items = new List<Item>();

        for (int x = minX; x < maxX; x++)
        {
            var column = shape.GetByIndex(x);

            var minY = column.MinY;
            var maxY = column.MaxY;

            for (int y = minY; y < maxY; y++)
            {
                var rawPosition = new Vector2Int(x, y);
                var position = rawPosition * _prefab.Size;

                var item = Spawn(_prefab, position);

                item.TryInitialize(rawPosition);

                items.Add(item);
            }
        }

        return items;
    }
}