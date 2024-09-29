public class SFXMuteToggle : ToggleListener
{
    protected override void HandleInitialized()
    {
        SetIsOn(!SFX.IsMuted);
    }

    protected override void Listen(bool enabled)
    {
        if (enabled) SFX.UnMute();
        else SFX.Mute();
    }
}