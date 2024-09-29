using System.Linq;
using UnityEngine;

public class ItemsMatchCount : MonoBehaviour
{
    [SerializeField] private ItemsMatchFind _matchFinder;
    [SerializeField] private ItemList _itemList;

    public bool NoHasMatches => MatchCount == 0;

    private int MatchCount => GetMatchCount();

    private int GetMatchCount()
    {
        int count = 0;
        int lastCount = 0;

        for (int i = 0; i < _itemList.Count; i++)
        {
            var item = _itemList.GetByIndex(i);

            if (item == null) continue;

            int newCount = _matchFinder.FindAllMatches(item).Count();

            if (newCount <= lastCount) continue;

            lastCount = newCount - 1;
            count += newCount - 1;
        }

        return count;
    }
}