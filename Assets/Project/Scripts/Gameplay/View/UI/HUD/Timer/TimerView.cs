using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _format = "{0:d2}:{1:d2}";

    private void OnEnable()
    {
        Refresh(_timer.Value);

        _timer.Updated += Refresh;
    }

    private void Refresh(int value)
    {
        var minutes = value / 60;
        var seconds = value % 60;

        _text.text = string.Format(_format, minutes, seconds);
    }

    private void OnDisable()
    {
        _timer.Updated -= Refresh;
    }
}