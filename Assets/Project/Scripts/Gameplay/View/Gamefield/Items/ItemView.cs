using System;
using UnityEngine;

public class ItemView : Initializable<Sprite>
{
    [SerializeField] private Item _item;
    [SerializeField] private SpriteRenderer _renderer;

    public Item Item => _item;
    public Color Color { get; private set; }

    protected override void Initialize(Sprite sprite)
    {
        Color = GetColorByName(sprite.name);

        _renderer.sprite = sprite;
    }

    private Color GetColorByName(string name) => name switch
    {
        "Blue" => Color.blue,
        "Cyan" => Color.cyan,
        "Green" => Color.green,
        "Red" => Color.red,
        "Pink" => Color.magenta,
        "Yellow" => Color.yellow,
        _ => throw new ArgumentException()
    }; 

    private void OnMouseDown()
    {
        _item.Select();
    }
}