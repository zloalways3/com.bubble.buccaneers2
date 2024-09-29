using TMPro;
using UnityEngine;

public class LoadLevelButton : ButtonListener
{
#if UNITY_EDITOR
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private string _format = "{0}";
#endif
    [SerializeField] private string _gameplaySceneName = "Gameplay";
    [SerializeField] [Min(1)] private int _level = 1;
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_amountText == null) return;
        _amountText.text = string.Format(_format, _level);
    }
#endif

    protected override void Listen()
    {
        if (!Level.TrySet(_level)) return;

        SceneLoad.Load(_gameplaySceneName);
    }
}