using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class ToggleListener : UIListener
{
    private Toggle _toggle;

    protected virtual void Listen(bool enabled) { }
    protected virtual void HandleInitialized() { }

    private void Start()
    {
        _toggle = GetComponent<Toggle>();

        _toggle.onValueChanged.AddListener(Listen);
        _toggle.onValueChanged.AddListener((_) => Listen());

        HandleInitialized();
    }

    protected void SetIsOn(bool enabled)
    {
        _toggle.SetIsOnWithoutNotify(enabled);
    }
}