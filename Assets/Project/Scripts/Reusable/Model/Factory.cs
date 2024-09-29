using UnityEngine;

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    protected virtual Transform Parent => transform;

    protected T Spawn(T prefab)
    {
        return Spawn(prefab, Vector3.zero);
    }

    protected T Spawn(T prefab, Vector2 rawPosition)
    {
        var position = (Vector3)rawPosition + Vector3.forward * transform.localPosition.z;
        var instance = Spawn(prefab, position);

        return instance;
    }

    protected T Spawn(T prefab, Vector3 position)
    {
        var parent = Parent != null ? Parent : transform;

        var instance = Instantiate(prefab);

        instance.transform.parent = parent;
        instance.transform.localPosition = position;

        return instance;
    }
}