public class BackgroundMusicMuteToggle : ToggleListener
{
    protected override void HandleInitialized()
    {
        SetIsOn(!BackgroundMusic.IsMuted);
    }

    protected override void Listen(bool enabled)
    {
        if (enabled) BackgroundMusic.UnMute();
        else BackgroundMusic.Mute();
    }
}