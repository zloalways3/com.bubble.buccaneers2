using System.Collections.Generic;
using System.Linq;

public class ItemViewList : Initializable<IEnumerable<ItemView>>
{
    private List<ItemView> _views;

    public int Count => _views.Count;

    public ItemView GetByIndex(int index)
    {
        return _views[index];
    }

    public ItemView GetByItem(Item item)
    {
        return _views.FirstOrDefault(view => view.Item == item);
    }

    protected override void Initialize(IEnumerable<ItemView> views)
    {
        _views = new List<ItemView>(views);
    }
}