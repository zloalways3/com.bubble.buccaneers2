using System;
using UnityEngine;

public class ItemDestroyView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] [Min(1)] private int _particlesCount = 25;
    [SerializeField] private ItemViewList _viewList;

    [Obsolete]
    private void Awake()
    {
        Item.Destroyed += Show;
    }

    [Obsolete]
    private void Show(Item item)
    {
        transform.position = item.transform.position;
        _particles.startColor = _viewList.GetByItem(item).Color;

        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        _particles.Emit(emitParams, _particlesCount);
    }

    [Obsolete]
    private void OnDestroy()
    {
        Item.Destroyed -= Show;
    }
}