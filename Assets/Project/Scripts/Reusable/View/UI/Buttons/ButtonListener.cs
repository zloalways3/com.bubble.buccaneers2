using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonListener : UIListener
{
    protected virtual void HandleAwake() { }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Listen);
        HandleAwake();
    }
}