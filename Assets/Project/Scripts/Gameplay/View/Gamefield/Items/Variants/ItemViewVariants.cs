using System.Collections.Generic;
using UnityEngine;

public class ItemViewVariants : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteVariants;

    public static int Count { get; private set; }

    private void Awake()
    {
        Count = _spriteVariants.Count;
    }

    public Sprite GetByIndex(int index)
    {
        return _spriteVariants[index];
    }
}