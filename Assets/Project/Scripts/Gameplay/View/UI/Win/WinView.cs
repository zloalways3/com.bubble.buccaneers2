using UnityEngine;

public class WinView : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private ItemsMatchFind _matchFind;
    [SerializeField] private ItemsMatchCount _matchCount;

    private void Awake()
    {
        _matchFind.Finded += (_) => TryShow();
    }

    private void TryShow()
    {
        if (!_matchCount.NoHasMatches) return;

        _view.SetActive(true);
    }

    private void OnDestroy()
    {
        _matchFind.Finded -= (_) => TryShow();
    }
}