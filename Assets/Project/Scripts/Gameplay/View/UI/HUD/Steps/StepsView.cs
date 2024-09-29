using TMPro;
using UnityEngine;

public class StepsView : MonoBehaviour
{
    [SerializeField] private Steps _steps;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _format = "{0}";

    private void OnEnable()
    {
        Refresh(_steps.Value);

        _steps.Changed += Refresh;
    }

    private void Refresh(int value)
    {
        _text.text = string.Format(_format, value);
    }

    private void OnDisable()
    {
        _steps.Changed -= Refresh;
    }
}