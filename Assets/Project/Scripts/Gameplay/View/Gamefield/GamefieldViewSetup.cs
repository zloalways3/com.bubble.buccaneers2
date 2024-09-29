using System.Collections.Generic;
using UnityEngine;

public class GamefieldViewSetup : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GamefieldSetup _gamefieldSetup;
    [SerializeField] private ItemList _itemList;

    [Header("Initializable")]
    [SerializeField] private ItemViewList _viewList;
    [SerializeField] private ItemViewSetup _viewSetup;

    private void Awake()
    {
        _gamefieldSetup.Initialized += Initialize;
    }

    private void Initialize()
    {
        var itemCount = _itemList.Count;

        var views = new List<ItemView>();

        for(int i = 0; i < itemCount; i++)
        {
            var item = _itemList.GetByIndex(i);

            if (!item.TryGetComponent(out ItemView view)) continue;

            views.Add(view);
        }

        _viewList.TryInitialize(views);
        _viewSetup.TryInitialize();
    }

    private void OnDestroy()
    {
        _gamefieldSetup.Initialized += Initialize;
    }
}