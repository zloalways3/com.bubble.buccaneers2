using UnityEngine;

public class SFX : MonoBehaviour
{
    private const string MuteKey = "SFXMuted";

    [SerializeField] private AudioSource _source;

    private static AudioSource _staticSource;

    public static bool IsMuted => PlayerPrefs.HasKey(MuteKey);

    public static void Play()
    {
        _staticSource.Play();
    }

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