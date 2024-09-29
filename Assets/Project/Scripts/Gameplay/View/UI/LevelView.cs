using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _format = "{0}";

    private void OnEnable()
    {
        _text.text = string.Format(_format, Level.Value);
    }
}