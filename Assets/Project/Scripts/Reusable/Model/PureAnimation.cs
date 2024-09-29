using System;
using System.Collections;
using UnityEngine;

public class PureAnimation
{
    private readonly MonoBehaviour _context;

    public PureAnimation(MonoBehaviour context) => _context = context;

    public void Play(float duration, Action<float> progressCallback)
    {
        Play(duration, progressCallback, null);
    }

    public void Play(float duration, Action<float> callback, Action endCallback)
    {
        _context.StartCoroutine(GetAnimation(duration, callback, endCallback));
    }

    private IEnumerator GetAnimation(float duration, Action<float> callback, Action animationEnded)
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        while (progress < 1f)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;
            callback(progress);
            yield return null;
        }
        
        callback(1f);

        animationEnded?.Invoke();
    }
}