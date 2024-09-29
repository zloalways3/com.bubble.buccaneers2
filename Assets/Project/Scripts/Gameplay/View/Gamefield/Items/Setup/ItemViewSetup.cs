using UnityEngine;

public class ItemViewSetup : Initializable
{
    [SerializeField] private ItemViewVariants _viewVariants;
    [SerializeField] private ItemViewList _viewList;

    protected override void Initialize()
    {
        var viewCount = _viewList.Count;

        for (int i = 0; i < viewCount; i++)
        {
            var view = _viewList.GetByIndex(i);

            var item = view.Item;
            var id = item.Id;

            var sprite = _viewVariants.GetByIndex(id);

            view.TryInitialize(sprite);
        }
    }
}