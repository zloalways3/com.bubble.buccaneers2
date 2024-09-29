using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _format = "{0}";

    private void OnEnable()
    {
        Refresh(_score.Value);

        _score.Changed += Refresh;
    }

    private void Refresh(int value)
    {
        _text.text = string.Format(_format, value);
    }

    private void OnDisable()
    {
        _score.Changed -= Refresh;
    }
}