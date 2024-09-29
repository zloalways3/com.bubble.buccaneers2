using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private const string MuteKey = "BackgroundLoopMuted";

    [SerializeField] private AudioSource _source;

    private static AudioSource _staticSource;

    public static bool IsMuted => PlayerPrefs.HasKey(MuteKey);

    public static void Mute()
    {
        _staticSource.mute = true;
        PlayerPrefs.SetInt(MuteKey, 0);
    }

    public static void UnMute()
    {
        _staticSource.mute = false;
        PlayerPrefs.DeleteKey(MuteKey);
    }

    private void Awake()
    {
        _staticSource = _source;

        if (!IsMuted) return;

        Mute();
    }
}