using UnityEngine;

public abstract class Initializable : MonoBehaviour
{
    private bool _isInitialized;

    protected abstract void Initialize();

    public bool TryInitialize()
    {
        if (_isInitialized) return false;

        Initialize();
        _isInitialized = true;

        return true;
    }
}

public abstract class Initializable<T> : MonoBehaviour
{
    private bool _isInitialized;

    protected abstract void Initialize(T args);

    public bool TryInitialize(T args)
    {
        if (_isInitialized) return false;

        Initialize(args);
        _isInitialized = true;

        return true;
    }
}