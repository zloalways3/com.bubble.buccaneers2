using UnityEngine;

public class LoseView : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Timer _timer;

    private void Awake()
    {
        _timer.Expired += Show;
    }

    private void Show()
    {
        _view.SetActive(true);
    }

    private void OnDestroy()
    {
        _timer.Expired -= Show;
    }
}